CREATE TABLE book (
    id BIGSERIAL NOT NULL PRIMARY KEY,
    title TEXT NULL,
    author TEXT NULL,
    price DECIMAL(18,2) NOT NULL,
    launch_date TIMESTAMP(6) NOT NULL
);