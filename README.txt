Tecnologías utilizadas:
*Asp.Net Core.
*PostgreSQL.

Pasos para configurar el proyecto:

1. Clonar el proyecto.
2. En el archivo appsettings.development.json especificar los parámetros de la base de datos (PostgreSQL), es decir, el host, usuario, nombre de la base de datos, y la contraseña.

Nota:
Este proyecto utiliza data seeding para cargar datos iniciales.

Endpoints:

*Conductores:

Método HTTP GET:
	<--Obtener todos los conductores-->
	https://localhost:44394/api/drivers

	<--Conductores disponibles-->
	https://localhost:44394/api/drivers/available

	<--Conductores disponibles en un radio de 3km -->
	https://localhost:44394/api/drivers/lat=<numero>&lng=<numero>

	<--Obtener conductor por un id específico-->
	https://localhost:44394/api/drivers/<id>

*Viajes:

	Http Post:
		<--Crear un viaje-->
		https://localhost:44394/api/trips
	Cuerpo:
		{"DriverId":<número>, "PassengerId":<número>, "OriginLatitude":<número>,"OriginLongitude":<número>, 		"destinationLatitude":<número>,"destinationLongitude":<número>}

	Http Post:
		<--Terminar viaje-->
		https://localhost:44394/api/trips/complete
	Cuerpo
		{"id":<numero>}

	Http GET:
		<--Viajes disponibles-->
		https://localhost:44394/api/trips

*Pasajeros:
	HTTP GET:
	<--Listado de todos los pasajeros-->
	https://localhost:44394/api/passengers
	<--Obtener un pasajero por su ID>
	https://localhost:44394/api/passengers/<id del pasajero (número)>
	<--Para un pasajero solicitando un viaje debe aparecer los tres conductores más cercanos-->
	https://localhost:44394/api/drivers/lat=<numero>&lng=<numero>
