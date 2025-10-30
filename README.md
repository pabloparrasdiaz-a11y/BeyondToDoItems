# BeyondToDoItems
Test exercise to Beyond

-Caracteristicas
	*CLiente Angular, simple para mostrar las tareas y la progresión.
	*Server .Net 8, arquitectura hexagonal, DDD.
	*Sin persistencia de datos.
	*Metodologia SOLID
	*Clean code

*Al crear una parte cliente y mostrar, se ha modificado la interface ITodoList para devolver valores (void)
*He añadido el atributo "TodoItemId" a Progression para mejor consistencia
-Create Angular .Net project, client-server
-Execute npm install
-Fichero .gitignore server
-url app https://localhost:61231/

-Se crea la capa de Domain
-Se crea la capa de Application
-Se crea la capa de Infrastructure

-Se añaden las entidades de negocio TotoItem, Progression
-Repositorios, he creado algo de complejidad tecnica al ser un proyecto bastante simple, en caso de escalabilidad y otras entidades.

