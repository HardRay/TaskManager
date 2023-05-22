CREATE DATABASE "TeamBuilding"
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Russian_Russia.1251'
    LC_CTYPE = 'Russian_Russia.1251'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;
GO

CREATE TABLE users(
	user_id	SERIAL PRIMARY KEY,
	email CHARACTER VARYING(50) NOT NULL,
	user_password CHARACTER VARYING(128) NOT NULL,
	first_name CHARACTER VARYING(100),
	last_name CHARACTER VARYING(100),
	middle_name CHARACTER VARYING(100),
	active BOOLEAN DEFAULT FALSE
)