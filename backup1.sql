--
-- PostgreSQL database dump
--

-- Dumped from database version 14.2
-- Dumped by pg_dump version 14.2

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: update_reception(character varying, integer); Type: FUNCTION; Schema: public; Owner: daniels
--

CREATE FUNCTION public.update_reception(character varying, integer) RETURNS void
    LANGUAGE sql
    AS $_$
	update reception set working_time=$1 where id_reception=$2;
$_$;


ALTER FUNCTION public.update_reception(character varying, integer) OWNER TO daniels;

--
-- Name: viesu_laiki(integer); Type: FUNCTION; Schema: public; Owner: daniels
--

CREATE FUNCTION public.viesu_laiki(wedding_id integer) RETURNS TABLE(date_to date, date_from date)
    LANGUAGE sql
    AS $_$
	select date_from,date_to from wedding where id_wedding=$1
$_$;


ALTER FUNCTION public.viesu_laiki(wedding_id integer) OWNER TO daniels;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: budget; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.budget (
    id_budget integer NOT NULL,
    food_costs numeric,
    reception_cost numeric,
    venue_rent numeric NOT NULL,
    musician_costs integer NOT NULL,
    total_costs numeric,
    CONSTRAINT budget_food_costs_check CHECK ((food_costs <= (2000)::numeric)),
    CONSTRAINT budget_reception_cost_check CHECK ((reception_cost <= (500)::numeric)),
    CONSTRAINT budget_total_costs_check CHECK ((total_costs <= (6500)::numeric)),
    CONSTRAINT budget_venue_rent_check CHECK ((venue_rent <= (600)::numeric))
);


ALTER TABLE public.budget OWNER TO daniels;

--
-- Name: budget_id_budget_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.budget_id_budget_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.budget_id_budget_seq OWNER TO daniels;

--
-- Name: budget_id_budget_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.budget_id_budget_seq OWNED BY public.budget.id_budget;


--
-- Name: contacts; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.contacts (
    id_contacts integer NOT NULL,
    telephone character(9) NOT NULL,
    email character varying(40) NOT NULL,
    adress character varying(40) NOT NULL,
    website character varying(45) DEFAULT 'none'::character varying
);


ALTER TABLE public.contacts OWNER TO daniels;

--
-- Name: contacts_id_contacts_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.contacts_id_contacts_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.contacts_id_contacts_seq OWNER TO daniels;

--
-- Name: contacts_id_contacts_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.contacts_id_contacts_seq OWNED BY public.contacts.id_contacts;


--
-- Name: food_budget; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.food_budget (
    id_food_budget integer NOT NULL,
    id_foods integer,
    id_budget integer
);


ALTER TABLE public.food_budget OWNER TO daniels;

--
-- Name: food_budget_id_food_budget_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.food_budget_id_food_budget_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.food_budget_id_food_budget_seq OWNER TO daniels;

--
-- Name: food_budget_id_food_budget_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.food_budget_id_food_budget_seq OWNED BY public.food_budget.id_food_budget;


--
-- Name: foods; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.foods (
    id_food integer NOT NULL,
    main_dish character varying(30) DEFAULT 'Spaghetti pasta with cottage cheese'::character varying,
    dessert character varying(30) DEFAULT 'Chocolate cake with cherry'::character varying,
    drink character varying(15) DEFAULT 'Pina Colada'::character varying
);


ALTER TABLE public.foods OWNER TO daniels;

--
-- Name: foods_id_food_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.foods_id_food_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.foods_id_food_seq OWNER TO daniels;

--
-- Name: foods_id_food_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.foods_id_food_seq OWNED BY public.foods.id_food;


--
-- Name: guest_contacts; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.guest_contacts (
    id_guest_contacts integer NOT NULL,
    id_contacts integer,
    id_guest integer
);


ALTER TABLE public.guest_contacts OWNER TO daniels;

--
-- Name: guest_contacts_id_guest_contacts_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.guest_contacts_id_guest_contacts_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.guest_contacts_id_guest_contacts_seq OWNER TO daniels;

--
-- Name: guest_contacts_id_guest_contacts_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.guest_contacts_id_guest_contacts_seq OWNED BY public.guest_contacts.id_guest_contacts;


--
-- Name: guests; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.guests (
    id_guest integer NOT NULL,
    name character varying(15),
    surname character varying(15),
    invintation_sent boolean
);


ALTER TABLE public.guests OWNER TO daniels;

--
-- Name: guest_invintation_view; Type: VIEW; Schema: public; Owner: daniels
--

CREATE VIEW public.guest_invintation_view AS
 SELECT g.name,
    g.surname,
    c.email
   FROM public.guests g,
    public.contacts c,
    public.guest_contacts gc
  WHERE (g.invintation_sent = false);


ALTER TABLE public.guest_invintation_view OWNER TO daniels;

--
-- Name: guests_id_guest_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.guests_id_guest_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.guests_id_guest_seq OWNER TO daniels;

--
-- Name: guests_id_guest_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.guests_id_guest_seq OWNED BY public.guests.id_guest;


--
-- Name: invintation; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.invintation (
    id_invintation integer NOT NULL,
    invintation_text character varying(200) NOT NULL,
    invintation_type character varying(15) DEFAULT 'Envelope'::character varying,
    recipient character varying(20)
);


ALTER TABLE public.invintation OWNER TO daniels;

--
-- Name: invintation_id_invintation_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.invintation_id_invintation_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.invintation_id_invintation_seq OWNER TO daniels;

--
-- Name: invintation_id_invintation_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.invintation_id_invintation_seq OWNED BY public.invintation.id_invintation;


--
-- Name: married_couple; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.married_couple (
    id_married_couple integer NOT NULL,
    bride_name character varying(15) NOT NULL,
    bride_surname character varying(15) NOT NULL,
    groom_name character varying(15) NOT NULL,
    groom_surname character varying(15) NOT NULL,
    wedding_carriers character varying(50)
);


ALTER TABLE public.married_couple OWNER TO daniels;

--
-- Name: married_couple_contacts; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.married_couple_contacts (
    id_married_couple_contacts integer NOT NULL,
    id_contacts integer,
    id_married_couple integer
);


ALTER TABLE public.married_couple_contacts OWNER TO daniels;

--
-- Name: married_couple_contacts_id_married_couple_contacts_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.married_couple_contacts_id_married_couple_contacts_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.married_couple_contacts_id_married_couple_contacts_seq OWNER TO daniels;

--
-- Name: married_couple_contacts_id_married_couple_contacts_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.married_couple_contacts_id_married_couple_contacts_seq OWNED BY public.married_couple_contacts.id_married_couple_contacts;


--
-- Name: married_couple_id_married_couple_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.married_couple_id_married_couple_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.married_couple_id_married_couple_seq OWNER TO daniels;

--
-- Name: married_couple_id_married_couple_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.married_couple_id_married_couple_seq OWNED BY public.married_couple.id_married_couple;


--
-- Name: musician_contacts; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.musician_contacts (
    id_musician_contacts integer NOT NULL,
    id_musicians integer,
    id_contacts integer
);


ALTER TABLE public.musician_contacts OWNER TO daniels;

--
-- Name: musician_contacts_id_musician_contacts_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.musician_contacts_id_musician_contacts_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.musician_contacts_id_musician_contacts_seq OWNER TO daniels;

--
-- Name: musician_contacts_id_musician_contacts_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.musician_contacts_id_musician_contacts_seq OWNED BY public.musician_contacts.id_musician_contacts;


--
-- Name: musicians; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.musicians (
    id_musicians integer NOT NULL,
    group_name character varying(20),
    group_type character varying(15),
    cost_per_hour numeric DEFAULT 50.0
);


ALTER TABLE public.musicians OWNER TO daniels;

--
-- Name: musicians_budget; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.musicians_budget (
    id_musicians_budget integer NOT NULL,
    id_musicians integer,
    id_budget integer
);


ALTER TABLE public.musicians_budget OWNER TO daniels;

--
-- Name: musicians_budget_id_musicians_budget_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.musicians_budget_id_musicians_budget_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.musicians_budget_id_musicians_budget_seq OWNER TO daniels;

--
-- Name: musicians_budget_id_musicians_budget_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.musicians_budget_id_musicians_budget_seq OWNED BY public.musicians_budget.id_musicians_budget;


--
-- Name: musicians_id_musicians_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.musicians_id_musicians_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.musicians_id_musicians_seq OWNER TO daniels;

--
-- Name: musicians_id_musicians_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.musicians_id_musicians_seq OWNED BY public.musicians.id_musicians;


--
-- Name: planner; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.planner (
    id_planner integer NOT NULL,
    name character varying(15) DEFAULT 'danie_wed'::character varying,
    id_wedding integer,
    id_reception integer
);


ALTER TABLE public.planner OWNER TO daniels;

--
-- Name: reception; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.reception (
    id_reception integer NOT NULL,
    receptionist_type character varying(15) DEFAULT 'waiter'::character varying,
    working_time character(11) NOT NULL,
    buffet boolean DEFAULT false,
    id_planner integer,
    reports_to integer
);


ALTER TABLE public.reception OWNER TO daniels;

--
-- Name: no_buffet; Type: VIEW; Schema: public; Owner: daniels
--

CREATE VIEW public.no_buffet AS
 SELECT p.name,
    r.receptionist_type
   FROM public.planner p,
    public.reception r
  WHERE ((p.id_planner = r.id_planner) AND (r.buffet = false));


ALTER TABLE public.no_buffet OWNER TO daniels;

--
-- Name: pastor; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.pastor (
    id_pastor integer NOT NULL,
    name character varying(15),
    surname character varying(15),
    price_per_ceremony integer DEFAULT 50,
    church character varying(20)
);


ALTER TABLE public.pastor OWNER TO daniels;

--
-- Name: pastor_contacts; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.pastor_contacts (
    id_pastor_contacts integer NOT NULL,
    id_pastor integer,
    id_contacts integer
);


ALTER TABLE public.pastor_contacts OWNER TO daniels;

--
-- Name: pastor_contacts_id_pastor_contacts_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.pastor_contacts_id_pastor_contacts_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.pastor_contacts_id_pastor_contacts_seq OWNER TO daniels;

--
-- Name: pastor_contacts_id_pastor_contacts_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.pastor_contacts_id_pastor_contacts_seq OWNED BY public.pastor_contacts.id_pastor_contacts;


--
-- Name: pastor_id_pastor_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.pastor_id_pastor_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.pastor_id_pastor_seq OWNER TO daniels;

--
-- Name: pastor_id_pastor_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.pastor_id_pastor_seq OWNED BY public.pastor.id_pastor;


--
-- Name: planner_id_planner_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.planner_id_planner_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.planner_id_planner_seq OWNER TO daniels;

--
-- Name: planner_id_planner_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.planner_id_planner_seq OWNED BY public.planner.id_planner;


--
-- Name: reception_budget; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.reception_budget (
    id_reception_budget integer NOT NULL,
    id_reception integer,
    id_budget integer
);


ALTER TABLE public.reception_budget OWNER TO daniels;

--
-- Name: reception_budget_id_reception_budget_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.reception_budget_id_reception_budget_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.reception_budget_id_reception_budget_seq OWNER TO daniels;

--
-- Name: reception_budget_id_reception_budget_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.reception_budget_id_reception_budget_seq OWNED BY public.reception_budget.id_reception_budget;


--
-- Name: reception_contacts; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.reception_contacts (
    id_reception_contacts integer NOT NULL,
    id_reception integer,
    id_contacts integer
);


ALTER TABLE public.reception_contacts OWNER TO daniels;

--
-- Name: reception_contacts_id_reception_contacts_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.reception_contacts_id_reception_contacts_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.reception_contacts_id_reception_contacts_seq OWNER TO daniels;

--
-- Name: reception_contacts_id_reception_contacts_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.reception_contacts_id_reception_contacts_seq OWNED BY public.reception_contacts.id_reception_contacts;


--
-- Name: reception_id_reception_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.reception_id_reception_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.reception_id_reception_seq OWNER TO daniels;

--
-- Name: reception_id_reception_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.reception_id_reception_seq OWNED BY public.reception.id_reception;


--
-- Name: wedding; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.wedding (
    id_wedding integer NOT NULL,
    date_from date NOT NULL,
    date_to date NOT NULL,
    id_planner integer
);


ALTER TABLE public.wedding OWNER TO daniels;

--
-- Name: summer_in_weding; Type: VIEW; Schema: public; Owner: daniels
--

CREATE VIEW public.summer_in_weding AS
 SELECT p.name,
    w.id_wedding
   FROM public.planner p,
    public.wedding w
  WHERE ((p.id_planner = w.id_planner) AND (w.date_from = '2022-06-24'::date));


ALTER TABLE public.summer_in_weding OWNER TO daniels;

--
-- Name: top_pastor_cost; Type: VIEW; Schema: public; Owner: daniels
--

CREATE VIEW public.top_pastor_cost AS
 SELECT pastor.name,
    pastor.surname,
    pastor.price_per_ceremony
   FROM public.pastor
  WHERE (((pastor.church)::text = 'Hungry Generation'::text) AND (pastor.price_per_ceremony IN ( SELECT max(pastor_1.price_per_ceremony) AS max
           FROM public.pastor pastor_1)));


ALTER TABLE public.top_pastor_cost OWNER TO daniels;

--
-- Name: venue; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.venue (
    id_venue integer NOT NULL,
    venue_name character varying(15) NOT NULL,
    price_per_day numeric,
    description character varying(200)
);


ALTER TABLE public.venue OWNER TO daniels;

--
-- Name: top_wedding_view; Type: VIEW; Schema: public; Owner: daniels
--

CREATE VIEW public.top_wedding_view AS
 SELECT venue.venue_name,
    venue.price_per_day
   FROM public.venue
  WHERE ((venue.id_venue = 1) AND (venue.price_per_day IN ( SELECT DISTINCT venue_1.price_per_day
           FROM public.venue venue_1
          WHERE (venue_1.price_per_day = (400)::numeric))));


ALTER TABLE public.top_wedding_view OWNER TO daniels;

--
-- Name: venu_budget; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.venu_budget (
    id_venue_budget integer NOT NULL,
    id_venue integer,
    id_budget integer
);


ALTER TABLE public.venu_budget OWNER TO daniels;

--
-- Name: venu_budget_id_venue_budget_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.venu_budget_id_venue_budget_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.venu_budget_id_venue_budget_seq OWNER TO daniels;

--
-- Name: venu_budget_id_venue_budget_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.venu_budget_id_venue_budget_seq OWNED BY public.venu_budget.id_venue_budget;


--
-- Name: venue_contacts; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.venue_contacts (
    id_venue_contacts integer NOT NULL,
    id_venue integer,
    id_contacts integer
);


ALTER TABLE public.venue_contacts OWNER TO daniels;

--
-- Name: venue_contacts_id_venue_contacts_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.venue_contacts_id_venue_contacts_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.venue_contacts_id_venue_contacts_seq OWNER TO daniels;

--
-- Name: venue_contacts_id_venue_contacts_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.venue_contacts_id_venue_contacts_seq OWNED BY public.venue_contacts.id_venue_contacts;


--
-- Name: venue_id_venue_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.venue_id_venue_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.venue_id_venue_seq OWNER TO daniels;

--
-- Name: venue_id_venue_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.venue_id_venue_seq OWNED BY public.venue.id_venue;


--
-- Name: wedding_budget; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.wedding_budget (
    id_wedding_budget integer NOT NULL,
    id_wedding integer,
    id_budget integer
);


ALTER TABLE public.wedding_budget OWNER TO daniels;

--
-- Name: wedding_budget_id_wedding_budget_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.wedding_budget_id_wedding_budget_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.wedding_budget_id_wedding_budget_seq OWNER TO daniels;

--
-- Name: wedding_budget_id_wedding_budget_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.wedding_budget_id_wedding_budget_seq OWNED BY public.wedding_budget.id_wedding_budget;


--
-- Name: wedding_foods; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.wedding_foods (
    id_wedding_foods integer NOT NULL,
    id_food integer,
    id_wedding integer
);


ALTER TABLE public.wedding_foods OWNER TO daniels;

--
-- Name: wedding_foods_id_wedding_foods_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.wedding_foods_id_wedding_foods_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.wedding_foods_id_wedding_foods_seq OWNER TO daniels;

--
-- Name: wedding_foods_id_wedding_foods_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.wedding_foods_id_wedding_foods_seq OWNED BY public.wedding_foods.id_wedding_foods;


--
-- Name: wedding_guests; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.wedding_guests (
    id_wedding_guest integer NOT NULL,
    id_guest integer,
    id_wedding integer
);


ALTER TABLE public.wedding_guests OWNER TO daniels;

--
-- Name: wedding_guests_id_wedding_guest_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.wedding_guests_id_wedding_guest_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.wedding_guests_id_wedding_guest_seq OWNER TO daniels;

--
-- Name: wedding_guests_id_wedding_guest_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.wedding_guests_id_wedding_guest_seq OWNED BY public.wedding_guests.id_wedding_guest;


--
-- Name: wedding_id_wedding_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.wedding_id_wedding_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.wedding_id_wedding_seq OWNER TO daniels;

--
-- Name: wedding_id_wedding_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.wedding_id_wedding_seq OWNED BY public.wedding.id_wedding;


--
-- Name: wedding_invintations; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.wedding_invintations (
    id_wedding_invintation integer NOT NULL,
    id_invintation integer,
    id_wedding integer
);


ALTER TABLE public.wedding_invintations OWNER TO daniels;

--
-- Name: wedding_invintations_id_wedding_invintation_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.wedding_invintations_id_wedding_invintation_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.wedding_invintations_id_wedding_invintation_seq OWNER TO daniels;

--
-- Name: wedding_invintations_id_wedding_invintation_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.wedding_invintations_id_wedding_invintation_seq OWNED BY public.wedding_invintations.id_wedding_invintation;


--
-- Name: wedding_married_couple; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.wedding_married_couple (
    id_wedding_married_couple integer NOT NULL,
    id_wedding integer,
    id_married_couple integer
);


ALTER TABLE public.wedding_married_couple OWNER TO daniels;

--
-- Name: wedding_married_couple_id_wedding_married_couple_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.wedding_married_couple_id_wedding_married_couple_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.wedding_married_couple_id_wedding_married_couple_seq OWNER TO daniels;

--
-- Name: wedding_married_couple_id_wedding_married_couple_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.wedding_married_couple_id_wedding_married_couple_seq OWNED BY public.wedding_married_couple.id_wedding_married_couple;


--
-- Name: wedding_musicians; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.wedding_musicians (
    id_wedding_musicians integer NOT NULL,
    id_musicians integer,
    id_wedding integer
);


ALTER TABLE public.wedding_musicians OWNER TO daniels;

--
-- Name: wedding_musicians_id_wedding_musicians_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.wedding_musicians_id_wedding_musicians_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.wedding_musicians_id_wedding_musicians_seq OWNER TO daniels;

--
-- Name: wedding_musicians_id_wedding_musicians_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.wedding_musicians_id_wedding_musicians_seq OWNED BY public.wedding_musicians.id_wedding_musicians;


--
-- Name: wedding_musicians_view; Type: VIEW; Schema: public; Owner: daniels
--

CREATE VIEW public.wedding_musicians_view AS
 SELECT m.group_name,
    m.group_type,
    w.id_wedding
   FROM public.musicians m,
    public.wedding w,
    public.wedding_musicians wm
  WHERE (wm.id_musicians = 2);


ALTER TABLE public.wedding_musicians_view OWNER TO daniels;

--
-- Name: wedding_pastor; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.wedding_pastor (
    id_wedding_pastor integer NOT NULL,
    id_wedding integer,
    id_pastor integer
);


ALTER TABLE public.wedding_pastor OWNER TO daniels;

--
-- Name: wedding_pastor_id_wedding_pastor_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.wedding_pastor_id_wedding_pastor_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.wedding_pastor_id_wedding_pastor_seq OWNER TO daniels;

--
-- Name: wedding_pastor_id_wedding_pastor_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.wedding_pastor_id_wedding_pastor_seq OWNED BY public.wedding_pastor.id_wedding_pastor;


--
-- Name: wedding_pastor_view; Type: VIEW; Schema: public; Owner: daniels
--

CREATE VIEW public.wedding_pastor_view AS
 SELECT p.name,
    w.id_wedding,
    w.date_from
   FROM public.pastor p,
    public.wedding w,
    public.wedding_pastor wp
  WHERE (wp.id_pastor = wp.id_wedding);


ALTER TABLE public.wedding_pastor_view OWNER TO daniels;

--
-- Name: wedding_reception; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.wedding_reception (
    id_wedding_reception integer NOT NULL,
    id_wedding integer,
    id_reception integer
);


ALTER TABLE public.wedding_reception OWNER TO daniels;

--
-- Name: wedding_reception_id_wedding_reception_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.wedding_reception_id_wedding_reception_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.wedding_reception_id_wedding_reception_seq OWNER TO daniels;

--
-- Name: wedding_reception_id_wedding_reception_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.wedding_reception_id_wedding_reception_seq OWNED BY public.wedding_reception.id_wedding_reception;


--
-- Name: wedding_venue; Type: TABLE; Schema: public; Owner: daniels
--

CREATE TABLE public.wedding_venue (
    id_wedding_venue integer NOT NULL,
    id_wedding integer,
    id_venue integer
);


ALTER TABLE public.wedding_venue OWNER TO daniels;

--
-- Name: wedding_venue_id_wedding_venue_seq; Type: SEQUENCE; Schema: public; Owner: daniels
--

CREATE SEQUENCE public.wedding_venue_id_wedding_venue_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.wedding_venue_id_wedding_venue_seq OWNER TO daniels;

--
-- Name: wedding_venue_id_wedding_venue_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: daniels
--

ALTER SEQUENCE public.wedding_venue_id_wedding_venue_seq OWNED BY public.wedding_venue.id_wedding_venue;


--
-- Name: budget id_budget; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.budget ALTER COLUMN id_budget SET DEFAULT nextval('public.budget_id_budget_seq'::regclass);


--
-- Name: contacts id_contacts; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.contacts ALTER COLUMN id_contacts SET DEFAULT nextval('public.contacts_id_contacts_seq'::regclass);


--
-- Name: food_budget id_food_budget; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.food_budget ALTER COLUMN id_food_budget SET DEFAULT nextval('public.food_budget_id_food_budget_seq'::regclass);


--
-- Name: foods id_food; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.foods ALTER COLUMN id_food SET DEFAULT nextval('public.foods_id_food_seq'::regclass);


--
-- Name: guest_contacts id_guest_contacts; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.guest_contacts ALTER COLUMN id_guest_contacts SET DEFAULT nextval('public.guest_contacts_id_guest_contacts_seq'::regclass);


--
-- Name: guests id_guest; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.guests ALTER COLUMN id_guest SET DEFAULT nextval('public.guests_id_guest_seq'::regclass);


--
-- Name: invintation id_invintation; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.invintation ALTER COLUMN id_invintation SET DEFAULT nextval('public.invintation_id_invintation_seq'::regclass);


--
-- Name: married_couple id_married_couple; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.married_couple ALTER COLUMN id_married_couple SET DEFAULT nextval('public.married_couple_id_married_couple_seq'::regclass);


--
-- Name: married_couple_contacts id_married_couple_contacts; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.married_couple_contacts ALTER COLUMN id_married_couple_contacts SET DEFAULT nextval('public.married_couple_contacts_id_married_couple_contacts_seq'::regclass);


--
-- Name: musician_contacts id_musician_contacts; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.musician_contacts ALTER COLUMN id_musician_contacts SET DEFAULT nextval('public.musician_contacts_id_musician_contacts_seq'::regclass);


--
-- Name: musicians id_musicians; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.musicians ALTER COLUMN id_musicians SET DEFAULT nextval('public.musicians_id_musicians_seq'::regclass);


--
-- Name: musicians_budget id_musicians_budget; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.musicians_budget ALTER COLUMN id_musicians_budget SET DEFAULT nextval('public.musicians_budget_id_musicians_budget_seq'::regclass);


--
-- Name: pastor id_pastor; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.pastor ALTER COLUMN id_pastor SET DEFAULT nextval('public.pastor_id_pastor_seq'::regclass);


--
-- Name: pastor_contacts id_pastor_contacts; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.pastor_contacts ALTER COLUMN id_pastor_contacts SET DEFAULT nextval('public.pastor_contacts_id_pastor_contacts_seq'::regclass);


--
-- Name: planner id_planner; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.planner ALTER COLUMN id_planner SET DEFAULT nextval('public.planner_id_planner_seq'::regclass);


--
-- Name: reception id_reception; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.reception ALTER COLUMN id_reception SET DEFAULT nextval('public.reception_id_reception_seq'::regclass);


--
-- Name: reception_budget id_reception_budget; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.reception_budget ALTER COLUMN id_reception_budget SET DEFAULT nextval('public.reception_budget_id_reception_budget_seq'::regclass);


--
-- Name: reception_contacts id_reception_contacts; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.reception_contacts ALTER COLUMN id_reception_contacts SET DEFAULT nextval('public.reception_contacts_id_reception_contacts_seq'::regclass);


--
-- Name: venu_budget id_venue_budget; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.venu_budget ALTER COLUMN id_venue_budget SET DEFAULT nextval('public.venu_budget_id_venue_budget_seq'::regclass);


--
-- Name: venue id_venue; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.venue ALTER COLUMN id_venue SET DEFAULT nextval('public.venue_id_venue_seq'::regclass);


--
-- Name: venue_contacts id_venue_contacts; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.venue_contacts ALTER COLUMN id_venue_contacts SET DEFAULT nextval('public.venue_contacts_id_venue_contacts_seq'::regclass);


--
-- Name: wedding id_wedding; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding ALTER COLUMN id_wedding SET DEFAULT nextval('public.wedding_id_wedding_seq'::regclass);


--
-- Name: wedding_budget id_wedding_budget; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_budget ALTER COLUMN id_wedding_budget SET DEFAULT nextval('public.wedding_budget_id_wedding_budget_seq'::regclass);


--
-- Name: wedding_foods id_wedding_foods; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_foods ALTER COLUMN id_wedding_foods SET DEFAULT nextval('public.wedding_foods_id_wedding_foods_seq'::regclass);


--
-- Name: wedding_guests id_wedding_guest; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_guests ALTER COLUMN id_wedding_guest SET DEFAULT nextval('public.wedding_guests_id_wedding_guest_seq'::regclass);


--
-- Name: wedding_invintations id_wedding_invintation; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_invintations ALTER COLUMN id_wedding_invintation SET DEFAULT nextval('public.wedding_invintations_id_wedding_invintation_seq'::regclass);


--
-- Name: wedding_married_couple id_wedding_married_couple; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_married_couple ALTER COLUMN id_wedding_married_couple SET DEFAULT nextval('public.wedding_married_couple_id_wedding_married_couple_seq'::regclass);


--
-- Name: wedding_musicians id_wedding_musicians; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_musicians ALTER COLUMN id_wedding_musicians SET DEFAULT nextval('public.wedding_musicians_id_wedding_musicians_seq'::regclass);


--
-- Name: wedding_pastor id_wedding_pastor; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_pastor ALTER COLUMN id_wedding_pastor SET DEFAULT nextval('public.wedding_pastor_id_wedding_pastor_seq'::regclass);


--
-- Name: wedding_reception id_wedding_reception; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_reception ALTER COLUMN id_wedding_reception SET DEFAULT nextval('public.wedding_reception_id_wedding_reception_seq'::regclass);


--
-- Name: wedding_venue id_wedding_venue; Type: DEFAULT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_venue ALTER COLUMN id_wedding_venue SET DEFAULT nextval('public.wedding_venue_id_wedding_venue_seq'::regclass);


--
-- Data for Name: budget; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.budget (id_budget, food_costs, reception_cost, venue_rent, musician_costs, total_costs) FROM stdin;
1	300	321	600	200	2042
7	300	321	600	200	2042
8	500	399	432	200	2041
9	770	322	600	200	2244
10	400	321	322	200	1243
\.


--
-- Data for Name: contacts; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.contacts (id_contacts, telephone, email, adress, website) FROM stdin;
1	20141411 	daniels.rafaels2002@gmail.com	Lidotaju iela 1	www.daniwed.lv
13	20364599 	Hard,rock@yahoo.com	Britan street 21	none
14	25564599 	Young.lifek@yahoo.com	Whath street 1	none
15	22164599 	My.gamek@yahoo.com	Tree street 7	none
16	20322599 	Yore.choise@yahoo.com	Wood street 11	none
17	20463467 	Fracis.chan@gmail.com	Hong kong street	Francis_Chang.com
18	20463499 	Benny@gmail.com	Palace street 1	Benny_Hing.com
19	20463887 	Joyce.m@gmail.com	Cristal street 44	Yoyce.Meyer.com
3	28385732 	marite.puce@gmail.com	Maskavas iela 42	none
4	28345732 	ivo.upe@gmail.com	Kronvalda iela 5	none
6	20474639 	Kristaps.prozingis@gmail.com	Liepajas iela 1	KR.P.LV
7	20114639 	Lauris.reiniks@gmail.com	Rigas iela 2	L.REINIKS.LV
8	20474639 	Cris.Brown@gmail.com	Wasington street 32	C.BROWN.COM
2	28385732 	lauma.rudze@gmail.com	Maskavas iela 42	none
5	28465648 	daiga.rudze@gmail.com	Liela iela 3	none
9	20467384 	Elsa.Winston@gmail.com	Wasington street 2	none
10	22267384 	John.Winston@gmail.com	Wasington street 2	none
11	20465384 	Jade.Smith@gmail.com	Chigao street 1	none
12	20467384 	Mark.Smith@gmail.com	Chigao street 1	none
20	20467374 	barman.m@gmail.com	club street 21	none
21	20411374 	g.supervise@gmail.com	Police street 1	none
22	24467374 	waiter.n@gmail.com	Club street 99	none
23	20467384 	paradise@org.com	Mountain lilian aley	paradise.com
24	20436384 	Miracle@org.com	Silicon street 21	Miracle.com
25	20455384 	DREAM@org.com	Sapuchi river park	dream.com
\.


--
-- Data for Name: food_budget; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.food_budget (id_food_budget, id_foods, id_budget) FROM stdin;
5	1	1
6	2	1
7	2	9
8	1	10
\.


--
-- Data for Name: foods; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.foods (id_food, main_dish, dessert, drink) FROM stdin;
2	Bacon eggs with chese	chream brule	cocacola
3	Soup with spagetti	cake with candy	beer
4	Lansanja	chream brule	juce
5	Chinese soup	ice cream	vine
1	Tuna fish with golden chese	chream brule	Vine
\.


--
-- Data for Name: guest_contacts; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.guest_contacts (id_guest_contacts, id_contacts, id_guest) FROM stdin;
1	8	1
2	6	3
3	7	5
\.


--
-- Data for Name: guests; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.guests (id_guest, name, surname, invintation_sent) FROM stdin;
1	Cris	Brown	t
3	Kristaps	Porzingis	f
4	Kaspars	Zars	t
5	Lauris	Reiniks	t
2	Jony	Brown	t
6	Ivo	Upe	t
\.


--
-- Data for Name: invintation; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.invintation (id_invintation, invintation_text, invintation_type, recipient) FROM stdin;
1	we welcome you to our wedding at apri 1 2022 ,from John and Emma	Envelope	Kristaps Prozingis
3	we welcome you to our wedding at apri 1 2022 ,from John and Emma	Envelope	Chris Brown
4	we welcome you to our wedding at apri 1 2022 ,from John and Emma	Envelope	Lauris Reiniks
2	we welcome you to our wedding at apri 1 2022 ,from John and Emma	Envelope	Ivo Upe
\.


--
-- Data for Name: married_couple; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.married_couple (id_married_couple, bride_name, bride_surname, groom_name, groom_surname, wedding_carriers) FROM stdin;
1	Elsa	Winston	John	Winston	Paul and Jasmine
2	Jade	Smith	Mark	Smith	Cris and Nichola
3	Jane	Cole	Cris	Cole	Tom and Nicky
4	Fiona	Lee	Marcus	Lee	Jake and Rebeka
\.


--
-- Data for Name: married_couple_contacts; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.married_couple_contacts (id_married_couple_contacts, id_contacts, id_married_couple) FROM stdin;
1	9	1
2	10	1
3	11	2
4	12	2
\.


--
-- Data for Name: musician_contacts; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.musician_contacts (id_musician_contacts, id_musicians, id_contacts) FROM stdin;
1	1	13
2	2	14
3	3	15
4	4	16
\.


--
-- Data for Name: musicians; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.musicians (id_musicians, group_name, group_type, cost_per_hour) FROM stdin;
1	Hard rock	quartet	50.0
2	Young life	septet	50.0
3	My game	duet	50.0
4	Yore choise	trio	50.0
\.


--
-- Data for Name: musicians_budget; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.musicians_budget (id_musicians_budget, id_musicians, id_budget) FROM stdin;
1	1	9
2	2	10
3	3	8
4	4	7
\.


--
-- Data for Name: pastor; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.pastor (id_pastor, name, surname, price_per_ceremony, church) FROM stdin;
1	Vlad	Salvcuk	52	Hungry Generation
2	Vlad	Salvcuck	50	Hungry Generation
3	Benny	Hinn	50	Wasington church
4	Joyce	Meyer	50	New york chuch
5	Francis	Chan	50	Hong Kong Church
\.


--
-- Data for Name: pastor_contacts; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.pastor_contacts (id_pastor_contacts, id_pastor, id_contacts) FROM stdin;
1	5	17
2	3	18
3	4	19
\.


--
-- Data for Name: planner; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.planner (id_planner, name, id_wedding, id_reception) FROM stdin;
1	danie_wed	1	1
\.


--
-- Data for Name: reception; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.reception (id_reception, receptionist_type, working_time, buffet, id_planner, reports_to) FROM stdin;
4	g.supervisor	09:00-21:00	f	1	\N
3	waiter	10:30-15:30	t	1	2
2	barman	14:00-22:00	t	1	4
1	barman&waiter	14:00-19:00	t	1	4
\.


--
-- Data for Name: reception_budget; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.reception_budget (id_reception_budget, id_reception, id_budget) FROM stdin;
1	1	8
2	2	10
3	3	1
\.


--
-- Data for Name: reception_contacts; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.reception_contacts (id_reception_contacts, id_reception, id_contacts) FROM stdin;
1	2	20
2	4	21
3	3	22
\.


--
-- Data for Name: venu_budget; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.venu_budget (id_venue_budget, id_venue, id_budget) FROM stdin;
1	1	8
2	2	1
3	3	9
\.


--
-- Data for Name: venue; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.venue (id_venue, venue_name, price_per_day, description) FROM stdin;
1	Paradise	400	We are located at the river side of nile great view all around
2	Miracle	355	Nice place for the loved ones in the mountains with great view
3	Dream	380	You will never forget it ,amaizing experince near the sea 
\.


--
-- Data for Name: venue_contacts; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.venue_contacts (id_venue_contacts, id_venue, id_contacts) FROM stdin;
1	1	23
2	2	24
3	3	25
\.


--
-- Data for Name: wedding; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.wedding (id_wedding, date_from, date_to, id_planner) FROM stdin;
1	2022-01-01	2022-01-02	1
2	2022-06-24	2022-09-22	1
3	2022-11-01	2022-12-04	1
4	2022-01-01	2022-01-04	1
5	2022-05-01	2022-05-04	1
\.


--
-- Data for Name: wedding_budget; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.wedding_budget (id_wedding_budget, id_wedding, id_budget) FROM stdin;
1	1	10
2	2	9
3	3	7
4	4	1
5	5	8
\.


--
-- Data for Name: wedding_foods; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.wedding_foods (id_wedding_foods, id_food, id_wedding) FROM stdin;
1	1	1
2	4	2
3	5	3
4	3	4
5	2	5
\.


--
-- Data for Name: wedding_guests; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.wedding_guests (id_wedding_guest, id_guest, id_wedding) FROM stdin;
1	1	1
2	2	1
3	5	2
4	4	3
5	3	4
6	2	5
7	1	5
\.


--
-- Data for Name: wedding_invintations; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.wedding_invintations (id_wedding_invintation, id_invintation, id_wedding) FROM stdin;
1	1	1
2	2	1
3	4	1
4	3	1
\.


--
-- Data for Name: wedding_married_couple; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.wedding_married_couple (id_wedding_married_couple, id_wedding, id_married_couple) FROM stdin;
1	1	1
2	2	2
3	3	3
4	5	4
\.


--
-- Data for Name: wedding_musicians; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.wedding_musicians (id_wedding_musicians, id_musicians, id_wedding) FROM stdin;
1	1	5
2	2	1
3	3	4
4	4	5
\.


--
-- Data for Name: wedding_pastor; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.wedding_pastor (id_wedding_pastor, id_wedding, id_pastor) FROM stdin;
1	1	1
2	1	1
3	1	2
4	3	3
5	4	4
6	5	5
7	2	5
\.


--
-- Data for Name: wedding_reception; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.wedding_reception (id_wedding_reception, id_wedding, id_reception) FROM stdin;
1	1	2
2	2	1
3	3	3
4	4	4
5	5	1
\.


--
-- Data for Name: wedding_venue; Type: TABLE DATA; Schema: public; Owner: daniels
--

COPY public.wedding_venue (id_wedding_venue, id_wedding, id_venue) FROM stdin;
1	1	1
2	2	1
3	3	2
4	4	3
5	5	2
\.


--
-- Name: budget_id_budget_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.budget_id_budget_seq', 10, true);


--
-- Name: contacts_id_contacts_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.contacts_id_contacts_seq', 25, true);


--
-- Name: food_budget_id_food_budget_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.food_budget_id_food_budget_seq', 8, true);


--
-- Name: foods_id_food_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.foods_id_food_seq', 5, true);


--
-- Name: guest_contacts_id_guest_contacts_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.guest_contacts_id_guest_contacts_seq', 3, true);


--
-- Name: guests_id_guest_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.guests_id_guest_seq', 6, true);


--
-- Name: invintation_id_invintation_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.invintation_id_invintation_seq', 4, true);


--
-- Name: married_couple_contacts_id_married_couple_contacts_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.married_couple_contacts_id_married_couple_contacts_seq', 4, true);


--
-- Name: married_couple_id_married_couple_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.married_couple_id_married_couple_seq', 4, true);


--
-- Name: musician_contacts_id_musician_contacts_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.musician_contacts_id_musician_contacts_seq', 4, true);


--
-- Name: musicians_budget_id_musicians_budget_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.musicians_budget_id_musicians_budget_seq', 4, true);


--
-- Name: musicians_id_musicians_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.musicians_id_musicians_seq', 4, true);


--
-- Name: pastor_contacts_id_pastor_contacts_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.pastor_contacts_id_pastor_contacts_seq', 3, true);


--
-- Name: pastor_id_pastor_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.pastor_id_pastor_seq', 5, true);


--
-- Name: planner_id_planner_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.planner_id_planner_seq', 1, false);


--
-- Name: reception_budget_id_reception_budget_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.reception_budget_id_reception_budget_seq', 3, true);


--
-- Name: reception_contacts_id_reception_contacts_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.reception_contacts_id_reception_contacts_seq', 3, true);


--
-- Name: reception_id_reception_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.reception_id_reception_seq', 5, true);


--
-- Name: venu_budget_id_venue_budget_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.venu_budget_id_venue_budget_seq', 3, true);


--
-- Name: venue_contacts_id_venue_contacts_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.venue_contacts_id_venue_contacts_seq', 3, true);


--
-- Name: venue_id_venue_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.venue_id_venue_seq', 3, true);


--
-- Name: wedding_budget_id_wedding_budget_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.wedding_budget_id_wedding_budget_seq', 5, true);


--
-- Name: wedding_foods_id_wedding_foods_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.wedding_foods_id_wedding_foods_seq', 5, true);


--
-- Name: wedding_guests_id_wedding_guest_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.wedding_guests_id_wedding_guest_seq', 7, true);


--
-- Name: wedding_id_wedding_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.wedding_id_wedding_seq', 5, true);


--
-- Name: wedding_invintations_id_wedding_invintation_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.wedding_invintations_id_wedding_invintation_seq', 4, true);


--
-- Name: wedding_married_couple_id_wedding_married_couple_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.wedding_married_couple_id_wedding_married_couple_seq', 4, true);


--
-- Name: wedding_musicians_id_wedding_musicians_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.wedding_musicians_id_wedding_musicians_seq', 4, true);


--
-- Name: wedding_pastor_id_wedding_pastor_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.wedding_pastor_id_wedding_pastor_seq', 7, true);


--
-- Name: wedding_reception_id_wedding_reception_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.wedding_reception_id_wedding_reception_seq', 5, true);


--
-- Name: wedding_venue_id_wedding_venue_seq; Type: SEQUENCE SET; Schema: public; Owner: daniels
--

SELECT pg_catalog.setval('public.wedding_venue_id_wedding_venue_seq', 5, true);


--
-- Name: budget budget_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.budget
    ADD CONSTRAINT budget_pkey PRIMARY KEY (id_budget);


--
-- Name: contacts contacts_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.contacts
    ADD CONSTRAINT contacts_pkey PRIMARY KEY (id_contacts);


--
-- Name: food_budget food_budget_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.food_budget
    ADD CONSTRAINT food_budget_pkey PRIMARY KEY (id_food_budget);


--
-- Name: foods foods_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.foods
    ADD CONSTRAINT foods_pkey PRIMARY KEY (id_food);


--
-- Name: guest_contacts guest_contacts_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.guest_contacts
    ADD CONSTRAINT guest_contacts_pkey PRIMARY KEY (id_guest_contacts);


--
-- Name: guests guests_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.guests
    ADD CONSTRAINT guests_pkey PRIMARY KEY (id_guest);


--
-- Name: invintation invintation_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.invintation
    ADD CONSTRAINT invintation_pkey PRIMARY KEY (id_invintation);


--
-- Name: married_couple_contacts married_couple_contacts_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.married_couple_contacts
    ADD CONSTRAINT married_couple_contacts_pkey PRIMARY KEY (id_married_couple_contacts);


--
-- Name: married_couple married_couple_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.married_couple
    ADD CONSTRAINT married_couple_pkey PRIMARY KEY (id_married_couple);


--
-- Name: musician_contacts musician_contacts_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.musician_contacts
    ADD CONSTRAINT musician_contacts_pkey PRIMARY KEY (id_musician_contacts);


--
-- Name: musicians_budget musicians_budget_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.musicians_budget
    ADD CONSTRAINT musicians_budget_pkey PRIMARY KEY (id_musicians_budget);


--
-- Name: musicians musicians_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.musicians
    ADD CONSTRAINT musicians_pkey PRIMARY KEY (id_musicians);


--
-- Name: pastor_contacts pastor_contacts_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.pastor_contacts
    ADD CONSTRAINT pastor_contacts_pkey PRIMARY KEY (id_pastor_contacts);


--
-- Name: pastor pastor_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.pastor
    ADD CONSTRAINT pastor_pkey PRIMARY KEY (id_pastor);


--
-- Name: planner planner_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.planner
    ADD CONSTRAINT planner_pkey PRIMARY KEY (id_planner);


--
-- Name: reception_budget reception_budget_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.reception_budget
    ADD CONSTRAINT reception_budget_pkey PRIMARY KEY (id_reception_budget);


--
-- Name: reception_contacts reception_contacts_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.reception_contacts
    ADD CONSTRAINT reception_contacts_pkey PRIMARY KEY (id_reception_contacts);


--
-- Name: reception reception_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.reception
    ADD CONSTRAINT reception_pkey PRIMARY KEY (id_reception);


--
-- Name: venu_budget venu_budget_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.venu_budget
    ADD CONSTRAINT venu_budget_pkey PRIMARY KEY (id_venue_budget);


--
-- Name: venue_contacts venue_contacts_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.venue_contacts
    ADD CONSTRAINT venue_contacts_pkey PRIMARY KEY (id_venue_contacts);


--
-- Name: venue venue_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.venue
    ADD CONSTRAINT venue_pkey PRIMARY KEY (id_venue);


--
-- Name: wedding_budget wedding_budget_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_budget
    ADD CONSTRAINT wedding_budget_pkey PRIMARY KEY (id_wedding_budget);


--
-- Name: wedding_foods wedding_foods_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_foods
    ADD CONSTRAINT wedding_foods_pkey PRIMARY KEY (id_wedding_foods);


--
-- Name: wedding_guests wedding_guests_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_guests
    ADD CONSTRAINT wedding_guests_pkey PRIMARY KEY (id_wedding_guest);


--
-- Name: wedding_invintations wedding_invintations_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_invintations
    ADD CONSTRAINT wedding_invintations_pkey PRIMARY KEY (id_wedding_invintation);


--
-- Name: wedding_married_couple wedding_married_couple_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_married_couple
    ADD CONSTRAINT wedding_married_couple_pkey PRIMARY KEY (id_wedding_married_couple);


--
-- Name: wedding_musicians wedding_musicians_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_musicians
    ADD CONSTRAINT wedding_musicians_pkey PRIMARY KEY (id_wedding_musicians);


--
-- Name: wedding_pastor wedding_pastor_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_pastor
    ADD CONSTRAINT wedding_pastor_pkey PRIMARY KEY (id_wedding_pastor);


--
-- Name: wedding wedding_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding
    ADD CONSTRAINT wedding_pkey PRIMARY KEY (id_wedding);


--
-- Name: wedding_reception wedding_reception_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_reception
    ADD CONSTRAINT wedding_reception_pkey PRIMARY KEY (id_wedding_reception);


--
-- Name: wedding_venue wedding_venue_pkey; Type: CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_venue
    ADD CONSTRAINT wedding_venue_pkey PRIMARY KEY (id_wedding_venue);


--
-- Name: food_budget food_budget_id_budget_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.food_budget
    ADD CONSTRAINT food_budget_id_budget_fkey FOREIGN KEY (id_budget) REFERENCES public.budget(id_budget);


--
-- Name: food_budget food_budget_id_foods_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.food_budget
    ADD CONSTRAINT food_budget_id_foods_fkey FOREIGN KEY (id_foods) REFERENCES public.foods(id_food);


--
-- Name: guest_contacts guest_contacts_id_contacts_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.guest_contacts
    ADD CONSTRAINT guest_contacts_id_contacts_fkey FOREIGN KEY (id_contacts) REFERENCES public.contacts(id_contacts);


--
-- Name: guest_contacts guest_contacts_id_guest_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.guest_contacts
    ADD CONSTRAINT guest_contacts_id_guest_fkey FOREIGN KEY (id_guest) REFERENCES public.guests(id_guest);


--
-- Name: married_couple_contacts married_couple_contacts_id_contacts_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.married_couple_contacts
    ADD CONSTRAINT married_couple_contacts_id_contacts_fkey FOREIGN KEY (id_contacts) REFERENCES public.contacts(id_contacts);


--
-- Name: married_couple_contacts married_couple_contacts_id_married_couple_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.married_couple_contacts
    ADD CONSTRAINT married_couple_contacts_id_married_couple_fkey FOREIGN KEY (id_married_couple) REFERENCES public.married_couple(id_married_couple);


--
-- Name: musician_contacts musician_contacts_id_contacts_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.musician_contacts
    ADD CONSTRAINT musician_contacts_id_contacts_fkey FOREIGN KEY (id_contacts) REFERENCES public.contacts(id_contacts);


--
-- Name: musician_contacts musician_contacts_id_musicians_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.musician_contacts
    ADD CONSTRAINT musician_contacts_id_musicians_fkey FOREIGN KEY (id_musicians) REFERENCES public.musicians(id_musicians);


--
-- Name: musicians_budget musicians_budget_id_budget_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.musicians_budget
    ADD CONSTRAINT musicians_budget_id_budget_fkey FOREIGN KEY (id_budget) REFERENCES public.budget(id_budget);


--
-- Name: musicians_budget musicians_budget_id_musicians_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.musicians_budget
    ADD CONSTRAINT musicians_budget_id_musicians_fkey FOREIGN KEY (id_musicians) REFERENCES public.musicians(id_musicians);


--
-- Name: pastor_contacts pastor_contacts_id_contacts_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.pastor_contacts
    ADD CONSTRAINT pastor_contacts_id_contacts_fkey FOREIGN KEY (id_contacts) REFERENCES public.contacts(id_contacts);


--
-- Name: pastor_contacts pastor_contacts_id_pastor_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.pastor_contacts
    ADD CONSTRAINT pastor_contacts_id_pastor_fkey FOREIGN KEY (id_pastor) REFERENCES public.pastor(id_pastor);


--
-- Name: planner planner_id_reception_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.planner
    ADD CONSTRAINT planner_id_reception_fkey FOREIGN KEY (id_reception) REFERENCES public.reception(id_reception);


--
-- Name: planner planner_id_wedding_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.planner
    ADD CONSTRAINT planner_id_wedding_fkey FOREIGN KEY (id_wedding) REFERENCES public.wedding(id_wedding);


--
-- Name: reception_budget reception_budget_id_budget_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.reception_budget
    ADD CONSTRAINT reception_budget_id_budget_fkey FOREIGN KEY (id_budget) REFERENCES public.budget(id_budget);


--
-- Name: reception_budget reception_budget_id_reception_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.reception_budget
    ADD CONSTRAINT reception_budget_id_reception_fkey FOREIGN KEY (id_reception) REFERENCES public.reception(id_reception);


--
-- Name: reception_contacts reception_contacts_id_contacts_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.reception_contacts
    ADD CONSTRAINT reception_contacts_id_contacts_fkey FOREIGN KEY (id_contacts) REFERENCES public.contacts(id_contacts);


--
-- Name: reception_contacts reception_contacts_id_reception_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.reception_contacts
    ADD CONSTRAINT reception_contacts_id_reception_fkey FOREIGN KEY (id_reception) REFERENCES public.reception(id_reception);


--
-- Name: reception reception_id_planner_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.reception
    ADD CONSTRAINT reception_id_planner_fkey FOREIGN KEY (id_planner) REFERENCES public.reception(id_reception);


--
-- Name: venu_budget venu_budget_id_budget_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.venu_budget
    ADD CONSTRAINT venu_budget_id_budget_fkey FOREIGN KEY (id_budget) REFERENCES public.budget(id_budget);


--
-- Name: venu_budget venu_budget_id_venue_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.venu_budget
    ADD CONSTRAINT venu_budget_id_venue_fkey FOREIGN KEY (id_venue) REFERENCES public.venue(id_venue);


--
-- Name: venue_contacts venue_contacts_id_contacts_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.venue_contacts
    ADD CONSTRAINT venue_contacts_id_contacts_fkey FOREIGN KEY (id_contacts) REFERENCES public.contacts(id_contacts);


--
-- Name: venue_contacts venue_contacts_id_venue_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.venue_contacts
    ADD CONSTRAINT venue_contacts_id_venue_fkey FOREIGN KEY (id_venue) REFERENCES public.venue(id_venue);


--
-- Name: wedding_budget wedding_budget_id_budget_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_budget
    ADD CONSTRAINT wedding_budget_id_budget_fkey FOREIGN KEY (id_budget) REFERENCES public.budget(id_budget);


--
-- Name: wedding_budget wedding_budget_id_wedding_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_budget
    ADD CONSTRAINT wedding_budget_id_wedding_fkey FOREIGN KEY (id_wedding) REFERENCES public.wedding(id_wedding);


--
-- Name: wedding_foods wedding_foods_id_food_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_foods
    ADD CONSTRAINT wedding_foods_id_food_fkey FOREIGN KEY (id_food) REFERENCES public.foods(id_food);


--
-- Name: wedding_foods wedding_foods_id_wedding_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_foods
    ADD CONSTRAINT wedding_foods_id_wedding_fkey FOREIGN KEY (id_wedding) REFERENCES public.wedding(id_wedding);


--
-- Name: wedding_guests wedding_guests_id_guest_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_guests
    ADD CONSTRAINT wedding_guests_id_guest_fkey FOREIGN KEY (id_guest) REFERENCES public.guests(id_guest);


--
-- Name: wedding_guests wedding_guests_id_wedding_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_guests
    ADD CONSTRAINT wedding_guests_id_wedding_fkey FOREIGN KEY (id_wedding) REFERENCES public.wedding(id_wedding);


--
-- Name: wedding_invintations wedding_invintations_id_invintation_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_invintations
    ADD CONSTRAINT wedding_invintations_id_invintation_fkey FOREIGN KEY (id_invintation) REFERENCES public.invintation(id_invintation);


--
-- Name: wedding_invintations wedding_invintations_id_wedding_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_invintations
    ADD CONSTRAINT wedding_invintations_id_wedding_fkey FOREIGN KEY (id_wedding) REFERENCES public.wedding(id_wedding);


--
-- Name: wedding_married_couple wedding_married_couple_id_married_couple_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_married_couple
    ADD CONSTRAINT wedding_married_couple_id_married_couple_fkey FOREIGN KEY (id_married_couple) REFERENCES public.married_couple(id_married_couple);


--
-- Name: wedding_married_couple wedding_married_couple_id_wedding_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_married_couple
    ADD CONSTRAINT wedding_married_couple_id_wedding_fkey FOREIGN KEY (id_wedding) REFERENCES public.wedding(id_wedding);


--
-- Name: wedding_musicians wedding_musicians_id_musicians_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_musicians
    ADD CONSTRAINT wedding_musicians_id_musicians_fkey FOREIGN KEY (id_musicians) REFERENCES public.musicians(id_musicians);


--
-- Name: wedding_musicians wedding_musicians_id_wedding_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_musicians
    ADD CONSTRAINT wedding_musicians_id_wedding_fkey FOREIGN KEY (id_wedding) REFERENCES public.wedding(id_wedding);


--
-- Name: wedding_pastor wedding_pastor_id_pastor_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_pastor
    ADD CONSTRAINT wedding_pastor_id_pastor_fkey FOREIGN KEY (id_pastor) REFERENCES public.pastor(id_pastor);


--
-- Name: wedding_pastor wedding_pastor_id_wedding_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_pastor
    ADD CONSTRAINT wedding_pastor_id_wedding_fkey FOREIGN KEY (id_wedding) REFERENCES public.wedding(id_wedding);


--
-- Name: wedding_reception wedding_reception_id_reception_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_reception
    ADD CONSTRAINT wedding_reception_id_reception_fkey FOREIGN KEY (id_reception) REFERENCES public.reception(id_reception);


--
-- Name: wedding_reception wedding_reception_id_wedding_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_reception
    ADD CONSTRAINT wedding_reception_id_wedding_fkey FOREIGN KEY (id_wedding) REFERENCES public.wedding(id_wedding);


--
-- Name: wedding_venue wedding_venue_id_venue_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_venue
    ADD CONSTRAINT wedding_venue_id_venue_fkey FOREIGN KEY (id_venue) REFERENCES public.venue(id_venue);


--
-- Name: wedding_venue wedding_venue_id_wedding_fkey; Type: FK CONSTRAINT; Schema: public; Owner: daniels
--

ALTER TABLE ONLY public.wedding_venue
    ADD CONSTRAINT wedding_venue_id_wedding_fkey FOREIGN KEY (id_wedding) REFERENCES public.wedding(id_wedding);


--
-- PostgreSQL database dump complete
--

