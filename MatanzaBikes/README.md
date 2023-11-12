# Mata# Matanza Bikes

## Descripci�n

Proyecto .NET 6 para administrar un inventario de Motos.

Para el almacenamiento de datos, se utiliza SQL Server. Los datos de conexi�n se almacenan como Secretos de Usuario en el archivo secrets.json

```bash
{
  "MatanzaBikes:ConnectionString": "Data Source=LAPTOP-QA3T2VH6\\SQLEXPRESS;Initial Catalog=MatanzaBikes;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False",
}
```

El modelo de datos posee dos entidades, Motos y Marcas, existiendo una relaci�n de 1:N entre Marcas y Motos como se puede ver en el Diagrama de Entidad Relaci�n.

![Alt text](../Resources/MatanzaBikesDER.png?raw=true "DER")

La manipulaci�n de datos se realiza utilizando Entity Framework.

La aplicaci�n ofrece un CRUD b�sico con Razor para el alta, baja, modificaci�n y eliminaci�n de las entidades.

La aplicaci�n expone las mismas acciones por medio de sus APIs.