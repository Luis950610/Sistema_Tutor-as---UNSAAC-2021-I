#-------------------------------------
# Lee exprecion y convierte en arreglo
#-------------------------------------
def MostrarArreglo(Arreglo):
     for i in range(len(Arreglo)):
          print(Arreglo[i])
def Linea_De_Codigo_R_Arreglo(Cadena_Instrucion,Operadores_Definidos_R):
    Formando_Instrucion_Nueva=[]
    SimboloEntonces_Encontrado=0
    Simbolo_Encontrado=0
    Eliminando_Vacio=0
    i=0
    TamCadena_instruccion=len(Cadena_Instrucion)
    Arreglo_Simbolos=[]
    Simbolo=""
    EncontradoSecuencia=0
    while (i<TamCadena_instruccion):
        Caracter_Extraido=Cadena_Instrucion[i]
        if(Caracter_Extraido!=" "):
            if(Caracter_Extraido in Operadores_Definidos_R):
                if(i+1<=len(Cadena_Instrucion)-1):
                    Caracter_Extraido2=Cadena_Instrucion[i+1]
                    if(Caracter_Extraido2 in ["=","-",">"]):
                        if(Simbolo!=""):
                            Arreglo_Simbolos=Arreglo_Simbolos+[Simbolo]
                        EncontradoSecuencia=1
                        i=i+1
                        Simbolo_Encontrado=0
                        Arreglo_Simbolos=Arreglo_Simbolos+[Caracter_Extraido+Caracter_Extraido2]
                        Simbolo=""
                if(EncontradoSecuencia==0):
                    if(Simbolo!=""):
                        Arreglo_Simbolos=Arreglo_Simbolos+[Simbolo]
                    Arreglo_Simbolos=Arreglo_Simbolos+[Caracter_Extraido]
                    Simbolo_Encontrado=0
                    Simbolo=""
                EncontradoSecuencia=0
            else:
                Simbolo_Encontrado=1
                Simbolo=Simbolo+Caracter_Extraido
                if(Simbolo in Operadores_Definidos_R):
                    Arreglo_Simbolos=Arreglo_Simbolos+[Simbolo]
                    Simbolo_Encontrado=0
                    Simbolo=""
        else:
            if(Simbolo_Encontrado==1):
                Arreglo_Simbolos=Arreglo_Simbolos+[Simbolo]
                Simbolo_Encontrado=0
                Simbolo=""
        i=i+1
    if(Simbolo_Encontrado==1):
        Arreglo_Simbolos=Arreglo_Simbolos+[Simbolo]
    return Arreglo_Simbolos
def BuscarPrimero_Vacio(Codigos_Intermedios):
    for i in range(len(Codigos_Intermedios)):
        if("" == Codigos_Intermedios[i][3]):
            return i
    return -1
def Analizar_Estructura(Arreglo_Codigo_R,Var,Count):
    Bucles=["while","for"]
    Condicional=["else","if"]
    Arreglo_Codigo_Medio_Final=[]
    Tam=len(Arreglo_Codigo_R)
    i=0
    AbiertoLLaves=0
    CerradoLLaves=0
    hayElse=0
    while(i<Tam):
        Primer_Elemento_Codigo=Arreglo_Codigo_R[i][0]
        if(Primer_Elemento_Codigo in Bucles):
            ArregloAux,Var,NroLlaves=Interpletar_Expresion_Bucle_while(Arreglo_Codigo_R[i],Var)
            Arreglo_Codigo_Medio_Final=Arreglo_Codigo_Medio_Final+ArregloAux
            IndiceInicioAux=len(Arreglo_Codigo_Medio_Final)-1
            AbiertoLLaves=1-NroLlaves
            if(AbiertoLLaves==0):
                AbiertoLLaves=1
                i=i+1
            else:
                i=i+2
            ArregloInteriorAnalizar=[]
            while(AbiertoLLaves!=CerradoLLaves):
                if("}" in Arreglo_Codigo_R[i]):
                    CerradoLLaves=CerradoLLaves+1
                if("{" in Arreglo_Codigo_R[i]):
                    AbiertoLLaves=AbiertoLLaves+1
                ArregloInteriorAnalizar=ArregloInteriorAnalizar+[Arreglo_Codigo_R[i]]
                i=i+1
            del ArregloInteriorAnalizar[len(ArregloInteriorAnalizar)-1]
            AbiertoLLaves=0
            CerradoLLaves=0
            ArregloAux,Var=Analizar_Estructura(ArregloInteriorAnalizar,Var,Count+len(Arreglo_Codigo_Medio_Final))
            IndiceTerminacionAux=len(ArregloAux)+len(Arreglo_Codigo_Medio_Final)+1
            Arreglo_Codigo_Medio_Final[IndiceInicioAux][3]=str(IndiceTerminacionAux+Count)
            Arreglo_Codigo_Medio_Final=Arreglo_Codigo_Medio_Final+ArregloAux+[["saltar","","",str(IndiceInicioAux-1+Count)]]
            i=i-1
        else:
            if(Primer_Elemento_Codigo == "if"):
                ArregloAux,Var,NroLlaves=Interpletar_Expresion_if(Arreglo_Codigo_R[i],Var)
                Arreglo_Codigo_Medio_Final=Arreglo_Codigo_Medio_Final+ArregloAux
                IndiceInicioAux=len(Arreglo_Codigo_Medio_Final)-1
                AbiertoLLaves=1-NroLlaves
                if(AbiertoLLaves==0):
                    AbiertoLLaves=1
                    i=i+1
                else:
                    i=i+2
                ArregloInteriorAnalizar=[]
                while(AbiertoLLaves!=CerradoLLaves):
                    if("}" in Arreglo_Codigo_R[i]):
                        CerradoLLaves=CerradoLLaves+1
                    if("{" in Arreglo_Codigo_R[i]):
                        AbiertoLLaves=AbiertoLLaves+1
                    ArregloInteriorAnalizar=ArregloInteriorAnalizar+[Arreglo_Codigo_R[i]]
                    i=i+1
                if("else" in ArregloInteriorAnalizar[len(ArregloInteriorAnalizar)-1]):
                     i=i+1
                     hayElse=1
                del ArregloInteriorAnalizar[len(ArregloInteriorAnalizar)-1]
                AbiertoLLaves=0
                CerradoLLaves=0
                ArregloAux,Var=Analizar_Estructura(ArregloInteriorAnalizar,Var,Count+len(Arreglo_Codigo_Medio_Final))
                if(hayElse==1):
                     hayElse=0
                     i=i-1
                if(i-1<=len(Arreglo_Codigo_R)-1):
                    i=i-1
                    if(len(Arreglo_Codigo_R[i])>=2):
                        if(Arreglo_Codigo_R[i][1] == "else"):
                            Continuar=0
                            if("{" in Arreglo_Codigo_R[i]):
                                AbiertoLLaves=0
                            else:
                                AbiertoLLaves=1
                            if(AbiertoLLaves==0):
                                AbiertoLLaves=1
                                i=i+1
                            else:
                                i=i+2
                            print(Arreglo_Codigo_R[i])
                            ArregloInteriorAnalizar=[]
                            while(AbiertoLLaves!=CerradoLLaves):
                                if("}" in Arreglo_Codigo_R[i]):
                                    CerradoLLaves=CerradoLLaves+1
                                if("{" in Arreglo_Codigo_R[i]):
                                    AbiertoLLaves=AbiertoLLaves+1
                                ArregloInteriorAnalizar=ArregloInteriorAnalizar+[Arreglo_Codigo_R[i]]
                                i=i+1
                            del ArregloInteriorAnalizar[len(ArregloInteriorAnalizar)-1]
                            AbiertoLLaves=0
                            CerradoLLaves=0
                            ArregloAux1,Var=Analizar_Estructura(ArregloInteriorAnalizar,Var,Count+0)
                            IndiceTerminacionAux=len(ArregloAux1)+len(Arreglo_Codigo_Medio_Final)
                            Arreglo_Codigo_Medio_Final[IndiceInicioAux][3]=str(IndiceTerminacionAux+Count+IndiceInicioAux)
                            Arreglo_Codigo_Medio_Final=Arreglo_Codigo_Medio_Final+ArregloAux+[["saltar","","",str(len(Arreglo_Codigo_Medio_Final)+len(ArregloAux)+len(ArregloAux1)+1+Count)]]
                            Arreglo_Codigo_Medio_Final=Arreglo_Codigo_Medio_Final+ArregloAux1
                            i=i-1
                        else:
                             i=i+1
                             IndiceTerminacionAux=len(ArregloAux)+len(Arreglo_Codigo_Medio_Final)
                             Arreglo_Codigo_Medio_Final[IndiceInicioAux][3]=str(IndiceTerminacionAux+Count)
                             Arreglo_Codigo_Medio_Final=Arreglo_Codigo_Medio_Final+ArregloAux
                             i=i-1
                    else:
                        i=i+1
                        IndiceTerminacionAux=len(ArregloAux)+len(Arreglo_Codigo_Medio_Final)
                        Arreglo_Codigo_Medio_Final[IndiceInicioAux][3]=str(IndiceTerminacionAux+Count)
                        Arreglo_Codigo_Medio_Final=Arreglo_Codigo_Medio_Final+ArregloAux
                        i=i-1
                else:
                    IndiceTerminacionAux=len(ArregloAux)+len(Arreglo_Codigo_Medio_Final)
                    Arreglo_Codigo_Medio_Final[IndiceInicioAux][3]=str(IndiceTerminacionAux+Count)
                    Arreglo_Codigo_Medio_Final=Arreglo_Codigo_Medio_Final+ArregloAux
                    i=i-1
            else:
                ArregloAux,Var=Interpletar_Expresion_Asignacion(Arreglo_Codigo_R[i],Var)
                Arreglo_Codigo_Medio_Final=Arreglo_Codigo_Medio_Final+ArregloAux         
        i=i+1
    return Arreglo_Codigo_Medio_Final,Var          
def Leer_Texto_En_R():
    print("Ingrese codigo en R")
    print("")
    i=0
    ArregloFinal=[]
    Operadores_Definidos_R=["while","for","(",")",":","{","}","+","-","*","/","^","**","%%","<=",">=","<",">","&&","||","==","!=","<-","seq"]#cadenas que R ya tiene preestablecidos
    while(True):
        N=input()
        if(N == "" or N==" " or N=="-1"):
            break
        ArregloFinal.append(Linea_De_Codigo_R_Arreglo(N,Operadores_Definidos_R))
    return ArregloFinal



#----------------------------------------------------
# Devuelve la exprecion a sufijo usando la clase pila
#----------------------------------------------------
class Pila:
    def __init__(self, x = None, sub_pila = None):
        self.cima = x
        self.sub_pila = sub_pila

    def apilar(self, x):       
        self.sub_pila = Pila(self.cima,self.sub_pila)
        self.cima = x

    def desapilar(self):
        if(not self.es_vacia()):
            self.cima = self.sub_pila.cima
            self.sub_pila = self.sub_pila.sub_pila

    def es_vacia(self):
        return self.cima == None

    def cima(self):
        if(not self.es_vacia()):
            return str(self.cima)
def Cambiar_Primeros_dos_Valores(A):
    Elemento1=A.cima
    A.desapilar()
    Elemento2=A.cima
    A.desapilar()
    A.apilar(Elemento1)
    A.apilar(Elemento2)
    print(Elemento1,Elemento2)
    return A
def longitud_pila(A):
    n = 0 
    B = Pila()  
    while(not A.es_vacia()):
        n = n + 1
        B.apilar(A.cima)
        A.desapilar()   
    while(not B.es_vacia()):
        A.apilar(B.cima)
        B.desapilar()
    return n

def mostrar_pila(A):
    B = Pila() 
    while(not A.es_vacia()):
        print(A.cima)
        B.apilar(A.cima)
        A.desapilar()  
    while(not B.es_vacia()):
        A.apilar(B.cima)
        B.desapilar()
        
def Reglas_Posfijas(Dato):
    if(Dato in ["+","-","%%","<=",">=","<",">","&&","||","!","==","!="]):
        return 1
    elif(Dato in ["*","/"]):
        return 2
    else:
        return 3
    
def Infijo_Posfijo(Expresion):
    Operaciones=["+","-","/","*","**","^","%%","<=",">=","<",">","&&","||","!","==","!="]
    pila=Pila()
    Arreglo_Resultado=[]
    for i in range(len(Expresion)):
        ElemActual=Expresion[i]
        if(ElemActual in Operaciones):
            if(longitud_pila(pila)!=0):
                ElementoAux=pila.cima
                if((ElementoAux in Operaciones)):
                    ValorActual=Reglas_Posfijas(ElemActual)
                    ValorAnterior=Reglas_Posfijas(ElementoAux)
                    if(ValorActual==ValorAnterior):
                        Arreglo_Resultado.append(pila.cima)
                        pila.desapilar()
                        pila.apilar(ElemActual)
                    else:
                       if(ValorActual>ValorAnterior):
                           pila.apilar(ElemActual)
                       else:
                           while(not(pila.es_vacia())):
                              Arreglo_Resultado.append(pila.cima)
                              pila.desapilar()
                              if(pila.cima=="("):
                                  break
                           pila.apilar(ElemActual)
                else:
                    pila.apilar(ElemActual)
            else:
                pila.apilar(ElemActual)
        else:
            if(ElemActual=="("):
                pila.apilar(ElemActual)
            else:
                if(ElemActual==")"):
                    while(not(pila.es_vacia())):
                        if(pila.cima == "("):
                            pila.desapilar()
                            break
                        Arreglo_Resultado.append(pila.cima)
                        pila.desapilar()
                else:
                    Arreglo_Resultado.append(ElemActual)
    while(not(pila.es_vacia())):
        Arreglo_Resultado.append(pila.cima)
        pila.desapilar()
    return Arreglo_Resultado



#--------------------------------------
# Interpreta el arreglo de la exprecion
#--------------------------------------
def Interpletar_Expresion_Asignacion(ArregloO,Var):
    Asignacion=["<-"]
    ArregloFinal=[]
    if(ArregloO[1] in Asignacion):
        Expresion=[]
        for i in range(2,len(ArregloO)):
            Expresion.append(ArregloO[i])
        Posfijo=Infijo_Posfijo(Expresion)
        if(len(Posfijo)==1):
             ArregloFinal.append(["Asignacion",Posfijo[0],"λ",ArregloO[0]])
             return ArregloFinal,Var
        Codifo_Intermedio,Var=Resolucion_Notacion_Polaca(Posfijo,Var)
        ArregloFinal=ArregloFinal+Codifo_Intermedio
        ArregloFinal.append(["Asignacion",Var,"λ",ArregloO[0]])
        return ArregloFinal,Var
    else:
        Expresion=[]
        for i in range(len(ArregloO)-2):
            Expresion.append(ArregloO[i])
        Posfijo=Infijo_Posfijo(Expresion)
        if(len(Posfijo)==1):
             ArregloFinal.append(["Asignacion",Posfijo[0],"λ",ArregloO[len(ArregloO)-1]])
             return ArregloFinal,Var
        Codifo_Intermedio,Var=Resolucion_Notacion_Polaca(Posfijo,Var)
        ArregloFinal=ArregloFinal+Codifo_Intermedio
        ArregloFinal.append(["Asignacion",Var,"λ",ArregloO[len(ArregloO)-1]])
        return ArregloFinal,Var
def Interpletar_Expresion_Booleanas(ArregloO,Var):
    Posfijo=Infijo_Posfijo(ArregloO)
    Codifo_Intermedio,Var=Resolucion_Notacion_Polaca(Posfijo,Var)
    return Codifo_Intermedio,Var
def Interpletar_Expresion_Bucle_while(ArregloB,Var):
    PatencesisAbierto=0
    PatencesisCerrados=0
    Encontrado=0
    OperacionBucle=[]
    for i in range(len(ArregloB)):
        Elemento=ArregloB[i]
        if(Encontrado==1):
            OperacionBucle=OperacionBucle+[Elemento]
            if(Elemento==")"):
                PatencesisCerrados=PatencesisCerrados+1
            if(Elemento=="("):
                PatencesisAbierto=PatencesisAbierto+1
            if(PatencesisAbierto==PatencesisCerrados):
                del OperacionBucle[len(OperacionBucle)-1]
                break
        if(Elemento=="(" and Encontrado==0):
            PatencesisAbierto=PatencesisAbierto+1
            Encontrado=1
    Codifo_Intermedio,Var=Interpletar_Expresion_Booleanas(OperacionBucle,Var)
    Codifo_Intermedio=Codifo_Intermedio+[["Escero",Var,"λ",""]]
    if("{" in ArregloB):
        return Codifo_Intermedio,Var,1
    else:
        return Codifo_Intermedio,Var,0
def Interpletar_Expresion_if(ArregloB,Var):
    PatencesisAbierto=0
    PatencesisCerrados=0
    Encontrado=0
    OperacionBucle=[]
    for i in range(len(ArregloB)):
        Elemento=ArregloB[i]
        if(Encontrado==1):
            OperacionBucle=OperacionBucle+[Elemento]
            if(Elemento==")"):
                PatencesisCerrados=PatencesisCerrados+1
            if(Elemento=="("):
                PatencesisAbierto=PatencesisAbierto+1
            if(PatencesisAbierto==PatencesisCerrados):
                del OperacionBucle[len(OperacionBucle)-1]
                break
        if(Elemento=="(" and Encontrado==0):
            PatencesisAbierto=PatencesisAbierto+1
            Encontrado=1
    Codifo_Intermedio,Var=Interpletar_Expresion_Booleanas(OperacionBucle,Var)
    Codifo_Intermedio=Codifo_Intermedio+[["Escero",Var,"λ",""]]
    if("{" in ArregloB):
        return Codifo_Intermedio,Var,1
    else:
        return Codifo_Intermedio,Var,0

     
#--------------------------------------------
# Imprimime la exprecion en codigo intermedio
#--------------------------------------------
def GenerarVariable_R(Var):
    if(Var==""):
        return "r1"
    else:
        Cadena=""
        for i in range(1,len(Var)):
            Cadena+=Var[i]
        Numero=int(Cadena)
        Numero+=1
        return "r"+str(Numero)
def Mostrar_Codigo_Intermedio(Arreglo):
    for i in range(len(Arreglo)):
        print(i,":",Arreglo[i])
    print(i+1,":",["","","",""])
def Resolucion_Notacion_Polaca(ExpresionPosfija,Var):
  Simbolos=["+","-","*","/","^","**","%%","<=",">=","<",">","&&","||","!","==","!="]
  Arreglo_Codigo_Intermedio=[]
  ArregloAux=[]
  for i in range(len(ExpresionPosfija)):
      if(ExpresionPosfija[i] in Simbolos):
          if(ExpresionPosfija[i] in "!"):
              ArregloAux.append(ExpresionPosfija[i])
              Operacion=ArregloAux[len(ArregloAux)-1]
              del ArregloAux[len(ArregloAux)-1]
              Elemento1=ArregloAux[len(ArregloAux)-1]
              del ArregloAux[len(ArregloAux)-1]
              Var=GenerarVariable_R(Var)
              Arreglo_Codigo_Intermedio.append([Operacion,Elemento1,"λ",Var])
              ArregloAux.append(Var)
          else:
              ArregloAux.append(ExpresionPosfija[i])
              Operacion=ArregloAux[len(ArregloAux)-1]
              del ArregloAux[len(ArregloAux)-1]
              Elemento1=ArregloAux[len(ArregloAux)-1]
              del ArregloAux[len(ArregloAux)-1]
              Elemento2=ArregloAux[len(ArregloAux)-1]
              del ArregloAux[len(ArregloAux)-1]
              Var=GenerarVariable_R(Var)
              Arreglo_Codigo_Intermedio.append([Operacion,Elemento2,Elemento1,Var])
              ArregloAux.append(Var)
      else:
          ArregloAux.append(ExpresionPosfija[i])
  return Arreglo_Codigo_Intermedio,Var

def Codigo_Intermedio():
    return 1
def NumeroEntero(Texto,Min,Max): 
     try:
         Numero=int(input(Texto))
     except SyntaxError:
             print("Error de sintaxix")
             print("Ingresar nuevamente")
             Numero=NumeroEntero(Texto,Min,Max)
             
             return Numero
     except (NameError, ValueError) as err:
             print("Error de sintaxix")
             print("Ingresar nuevamente")
             Numero=NumeroEntero(Texto,Min,Max)
             return Numero
     while(Numero>Max or Numero<Min):
             print("Fuera de rango")
             print("Ingresar nuevamente")
             try:
                 Numero=int(input(Texto))
             except SyntaxError:
                      print("Error de sintaxix")
                      print("Ingresar nuevamente")
                      Numero=NumeroEntero(Texto,Min,Max)
                      return Numero
             except (NameError, ValueError) as err:
                      print("Error de sintaxix")
                      print("Ingresar nuevamente")
                      Numero=NumeroEntero(Texto,Min,Max)
                      return Numero
     return Numero


     
#------------------------------
#             Menu
#------------------------------

def Menu():
     print()
     print("---------------------------")
     print("           Menu")
     print("1.- Ingresar Codigo")
     print("2.- Mostrar Codido Intermedio")
     print("3.- Salir")
     print("---------------------------")
     Opcion=NumeroEntero("Ingrese Opcion:",1,3)
     return Opcion
def Menu_Codigo_Medio():
     Opcion=Menu()
     Codigo_Ingresado=0
     Var=""
     Arreglo_Codido_R=[]
     while(Opcion!=3):
          if(Opcion==1):
               Var=""
               Arreglo_Codido_R=Leer_Texto_En_R()
               Codigo_Ingresado=1
          if(Opcion==2):
               if(Codigo_Ingresado==1):
                    Resultado,Var=Analizar_Estructura(Arreglo_Codido_R,Var,0)
                    print("---------------------------")
                    print("    Codigo intermedio")
                    Mostrar_Codigo_Intermedio(Resultado)
                    print("---------------------------")
                    print()
               else:
                    print("Ingrese codigo")
          Opcion=Menu()
     print("Fin")
     print("---------------------------")

Menu_Codigo_Medio()
input()
i=0;


#------------------------------
#      Codigo de prueba
#------------------------------
"""
i <- 0
while ( i < filas_a ) {
     j <- 0
     while ( j < columnas_b ) {
          k <- 0
          suma <- 0
          while ( k < columnas_a ) {
               suma <- suma + Matriz_A[i][k] * Matriz_B[k][j]
               k <- k + 1
          }
          Matriz_Resultado[i][j] <- suma
          j <- j + 1
     }
     i <- i + 1
}
"""
