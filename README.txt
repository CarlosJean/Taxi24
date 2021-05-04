Para configurar la base de datos se deben especificar los parámetros en el archivo appsettings.json.

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
