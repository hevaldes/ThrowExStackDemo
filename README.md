# Rethrow to preserve stack details

## Descripción de la regla

Cuando se inicia una excepción, parte de la información que contiene es el seguimiento de la pila. El seguimiento de la pila es una lista de la jerarquía de llamadas de método que comienza con el método que inicia la excepción y termina con el que la captura. Si se especifica una excepción en la instrucción throw y la excepción se vuelve a iniciar, el seguimiento de la pila se reinicia en el método actual y se pierde la lista de llamadas de método entre el método original que ha iniciado la excepción y el método actual. Para mantener la información de seguimiento de la pila original con la excepción, use la instrucción throw sin especificar la excepción

---

### Demostración

En esta demostración, tenemos una aplicación de consola la cual contiene el método principal y otros 3 métodos extra. 

* El método Main llama al método 1
* El método 1 llama al método 2
* Y el método 2 llama al método 3

![Image](https://github.com/hevaldes/ThrowExStackDemo/blob/master/assets/Solution.PNG "Rethrow to preserve stack details")

---

#### Demostración _throw ex;_ vs _throw;_

En esta demostración observaremos como _throw ex;_ elimina el _stack_ original que provocó el error impidiendo así un correcto seguimiento al origen de la excepción. 

1. El método _Main_ tiene una llamada al _Metodo1();_ aquí presionamos _F11_.

![Image](https://github.com/hevaldes/ThrowExStackDemo/blob/master/assets/Main.PNG "Rethrow to preserve stack details")

2. Metodo1() llama entonces a Metodo2()

![Image](https://github.com/hevaldes/ThrowExStackDemo/blob/master/assets/Metodo1.PNG "Rethrow to preserve stack details")

3. Metodo2() llama a Metodo3()

![Image](https://github.com/hevaldes/ThrowExStackDemo/blob/master/assets/Metodo2.PNG "Rethrow to preserve stack details")

4. Metodo3() intenará abrir un archivo que no existe, lo cual provocará un error en la línea número 35.

![Image](https://github.com/hevaldes/ThrowExStackDemo/blob/master/assets/Metodo3Error.PNG "Rethrow to preserve stack details")

5. Al regresar la ejecución hasta el método _Main_ que es donde se está haciendo el manejo del error, lo que tenemos es lo siguiente al evaluar la línea 12, específicamente la variable _ex_.

![Image](https://github.com/hevaldes/ThrowExStackDemo/blob/master/assets/ResultadoEx.PNG "Rethrow to preserve stack details")

6. Si dejamos ejecutar el programa gasta la línea 17, podremos ver que _throw ex;_ indica un lugar incorrecto como origen del error. En este caso el error dice que ocurrió en la línea 17 y eso no es correcto. 

![Image](https://github.com/hevaldes/ThrowExStackDemo/blob/master/assets/ResultadoThrowEx.PNG "Rethrow to preserve stack details")

7. Ahora comentaremos la línea 17 además de las líneas 14 y 15 que son informativas únicamente. 
![Image](https://github.com/hevaldes/ThrowExStackDemo/blob/master/assets/Commnet17line.PNG "Rethrow to preserve stack details")

8. Ejecutaremos y dejaremos que se realice solamente _throw;_ en la línea 19

![Image](https://github.com/hevaldes/ThrowExStackDemo/blob/master/assets/ResultadoThrow.PNG "Rethrow to preserve stack details")

9. Fin de la demostracion.

---


### En resumen

El manejador de error bien implementado nos permitirá un rápido diagnóstico de la falla y en consecuencia una resolución mas eficaz. Por ello el manejador de error es ideal cuando se le da valor al mismo. 

¿Cómo se le da valor al manejador de errores?

Registrando la excepción en algún sistema de monitoreo o bitácora. Si no se da valor a esto: 
* Es válido quitar los manejadores internos de error dejando uno en el método principal. 
* Si se mantienen los manejadores de error, se recomienda registrar la excepción. 

El siguiente artículo tiene una implementación basada en políticas para el manejo de excepciones: [Referencia: Exception Handling / Telemetry / Application Insights / NuGet Packages](https://github.com/hevaldes/ExceptionHandlingDemo "Rethrow to preserve stack details")