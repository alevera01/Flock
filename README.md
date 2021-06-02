<h1>Flock</h1>
<ol>
<li>Instalacion</li>
<li>Solucion</li>
<li>Consideraciones</li>
<li>Frameworks Utilizados</li>
</ol>
<h1>Instalacion</h1>
<p>En el proyecto Db se encuentran 2 scripts . Uno crea la base de datos y las tablas. El segundo realiza los inserts en las tablas
Cree 2 tablas de forma que  simule un esquema de Usuarios y Roles.
Modificar el conection string del web config con los datos del servidor de
la base de datos. El mismo actualmente permite conexiones utilizando autenticacion mediante credenciales de Windows.</p>
<h1>Solucion</h1>
<p>Contiene 4 proyectos. Db. Domains. WebApi. webApi2.Test</p>
<h1>Consideraciones</h1>
Se crea una aplicacion MVC, la cual contiene una API que expone los dos endpoins solicitados. Por otro lado se crearon vistas de forma que se puedan
probar los endpoints anteriormente descriptos</p>
<p>La vista que simula el login busca el usuario dentro de la base de datos.</p>
<p>Se escribe el log de la aplicacion en una carpeta dentro de la Web Application llamada Log</p>
<h1>Frameworks Utilizados</h1>
<li>Se utilizo Swagger para docuementar la api.</li> 
<li>Se utilizo Serilog para generar los log de aplicacion</li>
