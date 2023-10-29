# MatanzaBikes

## Descripción General

Elegir un dominio de aplicación a fin de realizar una sistema cuya funcionalidad será la
administración de una entidad importante de ese dominio. Es decir, básicamente se deberá
realizar el ABM (alta, baja, modificación) de esa entidad.

## Requerimientos funcionale

- Dar de alta elementos de esa entidad.
- Actualizar elementos - campos de esa entidad.
- Eliminar elementos de esa entidad.
- Listar o presentar por pantalla todos los elementos de esa entidad, con un buscador que tenga al menos dos campos por los cuales se permita buscar.


## Requisitos de diseño - Consideraciones técnicas

- La entidad principal debe tener al menos 10 campos.
- Al menos un campo debe ser tipo lista - selección (combo).
- Al menos un campo debe ser tipo numérico, con un rango de 1 a 1000 (Validar rango).
- Usar validación de campos segun se requiera. 
- La aplicación debe tener cobertura de tests unitarios.
- Preferentemente, la arquitectura debe hacer uso de algun patrón de diseño que se verá en clase.

## Requerimiento funcional adicional Deseable

Agregar una entidad de relación a la entidad principal, y desarrollar el alta de esa nueva entidad de relación junto con la asociación a la entidad principal. 
(ej. Si la entidad principal fuese la entidad "Provincia", una posible entidad de relación sería "Localidades", de esta forma se solicita el desarrollo del alta de localidad y la asociación a su Provincia correspondiente.

## Documentación

- Readme con descripcion y diagramas.
- Coleccion Postman con casos de uso.
- Documentacion con Swagger/OpenAPI en caso de API.

## Diagrama Entidad Relación

![Alt text](Resources/MatanzaBikesDER.png?raw=true "DER")

