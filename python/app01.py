# operazione di moltiplicazione
def Moltiplica(a, b = 1):
    return a * b
    
def Dividi(a, b = 1):
    return a / b

# tabellina
def Tabellina(base, rep, operazione):
    print(f"Tabellina del {base}")
    for n in range(1, rep + 1):
        print(f"{base} => {n} = {operazione(base, n)}")
    print("")

# quindi rendo la mia funzione più maneggevole
Tabellina(2, 10, Moltiplica)
# e amplio la mia possibilità di azione
Tabellina(2, 10, Dividi)