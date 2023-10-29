# MatanzaBikes

## Descripci�n General

Elegir un dominio de aplicaci�n a fin de realizar una sistema cuya funcionalidad ser� la
administraci�n de una entidad importante de ese dominio. Es decir, b�sicamente se deber�
realizar el ABM (alta, baja, modificaci�n) de esa entidad.

## Requerimientos funcionale

- Dar de alta elementos de esa entidad.
- Actualizar elementos - campos de esa entidad.
- Eliminar elementos de esa entidad.
- Listar o presentar por pantalla todos los elementos de esa entidad, con un buscador que tenga al menos dos campos por los cuales se permita buscar.


## Requisitos de dise�o - Consideraciones t�cnicas

- La entidad principal debe tener al menos 10 campos.
- Al menos un campo debe ser tipo lista - selecci�n (combo).
- Al menos un campo debe ser tipo num�rico, con un rango de 1 a 1000 (Validar rango).
- Usar validaci�n de campos segun se requiera. 
- La aplicaci�n debe tener cobertura de tests unitarios.
- Preferentemente, la arquitectura debe hacer uso de algun patr�n de dise�o que se ver� en clase.

## Requerimiento funcional adicional Deseable

Agregar una entidad de relaci�n a la entidad principal, y desarrollar el alta de esa nueva entidad de relaci�n junto con la asociaci�n a la entidad principal. 
(ej. Si la entidad principal fuese la entidad "Provincia", una posible entidad de relaci�n ser�a "Localidades", de esta forma se solicita el desarrollo del alta de localidad y la asociaci�n a su Provincia correspondiente.

## Documentaci�n

- Readme con descripcion y diagramas.
- Coleccion Postman con casos de uso.
- Documentacion con Swagger/OpenAPI en caso de API.

## Diagrama Entidad Relaci�n

![Alt text](Resources/MatanzaBikesDER.png?raw=true "DER")

