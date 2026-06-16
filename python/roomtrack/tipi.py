# come creo la tabella
def Init(telefono, cornetta):
    cornetta.execute("DROP TABLE IF EXISTS tipi")
    cornetta.execute("""
        CREATE TABLE IF NOT EXISTS tipi (
            idtipo INTEGER PRIMARY KEY AUTOINCREMENT,
            tipo TEXT,
            descrizione TEXT
        )
    """)

# come inserisco i dati in tabella
def Inserisci(telefono, cornetta):
    cornetta.execute(
        "INSERT INTO tipi (tipo, descrizione) VALUES (?, ?)", 
        (
            input("Nome:\t"), 
            input("Descrizione:\t")
        )
    )
    telefono.commit()

# come estraggo i dati dalla tabella
def Vedi(telefono, cornetta):
    dati = cornetta.execute("""
        SELECT *
        FROM tipi
    """)
    for riga in dati:
        print(riga)

# come aggiorno i dati in tabella
def Aggiorna(telefono, cornetta):
    cornetta.execute(
        "UPDATE tipi SET descrizione=? WHERE idtipo=?",
        (
            input("Descrizione:\t"), 
            int(input("Id da modificare:\t"))
        )
    )
    telefono.commit()

# come cancello i dati in tabella
def Cancella(telefono, cornetta):
    cornetta.execute(
        "DELETE FROM tipi WHERE idtipo=?", 
        (
            int(input("Id da cancellare:\t")),
        )
    )
    telefono.commit()

def Main(telefono, cornetta):
    print("-" * 20)
    print("Gestione TIPI")
    print("-" * 20)
    inEsecuzione = True
    while(inEsecuzione):
        comando = input("tipi>")
        if comando == "add": # Create
            Inserisci(telefono, cornetta)
        elif comando == "see": # Read
            Vedi(telefono, cornetta)
        elif comando == "mod": # Update
            Aggiorna(telefono, cornetta)
        elif comando == "del": # Delete
            Cancella(telefono, cornetta)
        elif comando == "exit": # Exit
            inEsecuzione = False
        elif comando == "reset": # Recreate
            Init(telefono, cornetta)
        else:
            print("comando sconosciuto")