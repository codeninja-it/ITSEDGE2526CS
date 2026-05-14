# come creo la tabella
def TipiInit(telefono, cornetta):
    cornetta.execute("DROP TABLE IF EXISTS tipi")
    cornetta.execute("""
        CREATE TABLE IF NOT EXISTS tipi (
            idtipo INTEGER PRIMARY KEY AUTOINCREMENT,
            tipo TEXT,
            descrizione TEXT
        )
    """)

# come inserisco i dati in tabella
def InserisciTipo(telefono, cornetta):
    cornetta.execute(
        "INSERT INTO tipi (tipo, descrizione) VALUES (?, ?)", 
        (
            input("Nome:\t"), 
            input("Descrizione:\t")
        )
    )
    telefono.commit()

# come estraggo i dati dalla tabella
def VediTipi(telefono, cornetta):
    dati = cornetta.execute("""
        SELECT *
        FROM tipi
    """)
    for riga in dati:
        print(riga)

# come aggiorno i dati in tabella
def AggiornaTipo(telefono, cornetta):
    cornetta.execute(
        "UPDATE tipi SET descrizione=? WHERE idtipo=?",
        (
            input("Descrizione:\t"), 
            int(input("Id da modificare:\t"))
        )
    )
    telefono.commit()

# come cancello i dati in tabella
def CancellaTipo(telefono, cornetta):
    cornetta.execute(
        "DELETE FROM tipi WHERE idtipo=?", 
        (
            int(input("Id da cancellare:\t")),
        )
    )
    telefono.commit()

def GestioneTipi(telefono, cornetta):
    print("-" * 20)
    print("Gestione TIPI")
    print("-" * 20)
    inEsecuzione = True
    while(inEsecuzione):
        comando = input("tipi>")
        if comando == "add": # Create
            InserisciTipo(telefono, cornetta)
        elif comando == "see": # Read
            VediTipi(telefono, cornetta)
        elif comando == "mod": # Update
            AggiornaTipo(telefono, cornetta)
        elif comando == "del": # Delete
            CancellaTipo(telefono, cornetta)
        elif comando == "exit": # Exit
            inEsecuzione = False
        elif comando == "reset": # Recreate
            TipiInit(telefono, cornetta)
        else:
            print("comando sconosciuto")