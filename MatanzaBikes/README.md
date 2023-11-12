# Mata# Matanza Bikes

## Descripción

Proyecto .NET 6 para administrar un inventario de Motos.

Para el almacenamiento de datos, se utiliza SQL Server. Los datos de conexión se almacenan como Secretos de Usuario en el archivo secrets.json

```bash
{
  "MatanzaBikes:ConnectionString": "Data Source=LAPTOP-QA3T2VH6\\SQLEXPRESS;Initial Catalog=MatanzaBikes;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False",
}
```

El modelo de datos posee dos entidades, Motos y Marcas, existiendo una relación de 1:N entre Marcas y Motos como se puede ver en el Diagrama de Entidad Relación.

![Alt text](../Resources/MatanzaBikesDER.png?raw=true "DER")

La manipulación de datos se realiza utilizando Entity Framework.

La aplicación ofrece un CRUD básico con Razor para el alta, baja, modificación y eliminación de las entidades.

La aplicación expone las mismas acciones por medio de sus APIs.