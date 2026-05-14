import sqlite3

# Gestione dell'entità tipi
telefono = sqlite3.connect("roomtrack.db")
cornetta = telefono.cursor()

# come creo la tabella
cornetta.execute("DROP TABLE tipi")
cornetta.execute("""
    CREATE TABLE IF NOT EXISTS tipi (
        idtipo INTEGER PRIMARY KEY AUTOINCREMENT,
        tipo TEXT,
        descrizione TEXT
    )
""")

# come inserisco i dati in tabella
cornetta.execute(
    "INSERT INTO tipi (tipo, descrizione) VALUES (?, ?)", 
    ("singola", "brutta") 
)
cornetta.execute(
    "INSERT INTO tipi (tipo, descrizione) VALUES (?, ?)", 
    ("suite", "bella")
)

telefono.commit()

# come estraggo i dati dalla tabella
dati = cornetta.execute("""
    SELECT *
    FROM tipi
""")
for riga in dati:
    print(riga)

# come aggiorno i dati in tabella
cornetta.execute(
    "UPDATE tipi SET descrizione=? WHERE idtipo=?",
    ("nella media", 1)
)

# come cancello i dati in tabella
cornetta.execute("")


telefono.commit()
telefono.close()