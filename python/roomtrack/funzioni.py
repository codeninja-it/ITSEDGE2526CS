# FUNZIONI DI UTILITY V.0.1.0
# ---------------------------

# sistema per creare selezione su più valori
def Tendina(cornetta, tabella, pk, descr):
    # prima ti dò le opzioni
    # controllando la natura del descrittore
    descrittore = descr
    if type(descr) == tuple:
        descrittore = "CONCAT(" + "', ' ', ".join(descr) + ") AS d"
    dati = cornetta.execute(f"""
        SELECT {pk}, {descrittore} 
        FROM {tabella}"""
    )
    buffer = []
    for riga in dati:
        buffer.append(f"{riga[0]}:{riga[1]}")
        
    print( " / ".join(buffer) )
    # poi ascolto e resituisco la tua risposta
    return input(f"Scegli {pk}:\t")