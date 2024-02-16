--
-- File generated with SQLiteStudio v3.4.4 on vie. feb. 16 17:36:57 2024
--
-- Text encoding used: UTF-8
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: adviser
CREATE TABLE IF NOT EXISTS adviser (
    id         INTEGER PRIMARY KEY
                       NOT NULL,
    company_id INTEGER REFERENCES company (id) ON DELETE RESTRICT
                       NOT NULL,
    department TEXT    NOT NULL,
    type       TEXT    NOT NULL,
    name       TEXT    NOT NULL,
    role       TEXT    NOT NULL
)
STRICT;


-- Table: company
CREATE TABLE IF NOT EXISTS company (
    id       INTEGER PRIMARY KEY
                     NOT NULL,
    name     TEXT    UNIQUE
                     NOT NULL,
    rfc      TEXT    UNIQUE
                     NOT NULL,
    type     TEXT    NOT NULL,
    address  TEXT    NOT NULL,
    postcode INTEGER NOT NULL,
    locality TEXT    NOT NULL,
    city     TEXT    NOT NULL,
    region   TEXT    NOT NULL,
    country  TEXT    NOT NULL,
    email    TEXT,
    phone    TEXT
)
STRICT;


-- Table: contact
CREATE TABLE IF NOT EXISTS contact (
    id         INTEGER PRIMARY KEY
                       NOT NULL,
    adviser_id INTEGER REFERENCES adviser (id) ON DELETE CASCADE
                       NOT NULL,
    type       TEXT    NOT NULL,
    value      TEXT    NOT NULL,
    extra      TEXT    NOT NULL
)
STRICT;


-- Table: itcm_career
CREATE TABLE IF NOT EXISTS itcm_career (
    id        INTEGER PRIMARY KEY
                      NOT NULL,
    name      TEXT    UNIQUE
                      NOT NULL,
    is_active INTEGER NOT NULL
)
STRICT;


-- Table: itcm_file
CREATE TABLE IF NOT EXISTS itcm_file (
    id         INTEGER PRIMARY KEY
                       NOT NULL,
    student_id INTEGER REFERENCES itcm_student (id) ON DELETE CASCADE
                       NOT NULL,
    type       TEXT    NOT NULL,
    name       TEXT    NOT NULL
)
STRICT;


-- Table: itcm_specialty
CREATE TABLE IF NOT EXISTS itcm_specialty (
    id        INTEGER PRIMARY KEY
                      NOT NULL,
    career_id INTEGER REFERENCES itcm_career (id) ON DELETE CASCADE
                      NOT NULL,
    name      TEXT    UNIQUE
                      NOT NULL,
    is_active INTEGER NOT NULL
)
STRICT;


-- Table: itcm_student
CREATE TABLE IF NOT EXISTS itcm_student (
    id            INTEGER PRIMARY KEY
                          NOT NULL,
    name          TEXT    NOT NULL,
    email         TEXT    NOT NULL,
    specialty_id  INTEGER REFERENCES itcm_specialty (id) ON DELETE RESTRICT
                          NOT NULL,
    gender        INT     NOT NULL,
    semester      TEXT    NOT NULL,
    register_date TEXT    NOT NULL,
    start_date    TEXT    NOT NULL,
    end_date      TEXT    NOT NULL,
    company_id    INTEGER REFERENCES company (id) ON DELETE RESTRICT
                          NOT NULL,
    department    TEXT    NOT NULL,
    schedule      TEXT    NOT NULL,
    is_active     INTEGER NOT NULL,
    notes         TEXT    NOT NULL
)
STRICT;


-- Index: ix_adviser_company_id
CREATE INDEX IF NOT EXISTS ix_adviser_company_id ON adviser (
    company_id
);


-- Index: ix_company_type
CREATE INDEX IF NOT EXISTS ix_company_type ON company (
    type
);


-- Index: ix_contact_adviser_id_type
CREATE INDEX IF NOT EXISTS ix_contact_adviser_id_type ON contact (
    adviser_id,
    type
);


-- Index: ix_file_lookup
CREATE INDEX IF NOT EXISTS ix_file_lookup ON itcm_file (
    student_id,
    type
);


-- Index: ix_specialty_lookup
CREATE INDEX IF NOT EXISTS ix_specialty_lookup ON itcm_specialty (
    career_id,
    is_active
);


-- Index: ix_student_company_id
CREATE INDEX IF NOT EXISTS ix_student_company_id ON itcm_student (
    company_id
);


-- Index: ix_student_specialty_id
CREATE INDEX IF NOT EXISTS ix_student_specialty_id ON itcm_student (
    specialty_id
);


COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
