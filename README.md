# BeyondToDoItems
Test exercise to Beyond

-Caracteristicas
	*CLiente Angular, simple para mostrar las tareas y la progresión.
	*Server .Net 8, arquitectura hexagonal, DDD.
	*Sin persistencia de datos, se trabajara en cache de memoria.
	*Metodologia SOLID
	*Clean code
	*Testing XUNIT

*Al crear una parte cliente y mostrar, se ha modificado la interface ITodoList para devolver valores (void)
*He añadido el atributo "TodoItemId" a Progression para mejor consistencia
-Create Angular .Net project, client-server
-Execute npm install
-Fichero .gitignore server

-Se crea la capa de Domain
-Se crea la capa de Application
-Se crea la capa de Infrastructure

-Se añaden las entidades de negocio TotoItem, Progression
-Repositorios, he creado algo de complejidad tecnica al ser un proyecto bastante simple, en caso de escalabilidad y otras entidades.
-He añadido un campo TotalPercent al TodoItem

-Cuales son las categorias del sistema????
-Este repositorio no tiene sentido, la logica de negocio no se debe aplicar en la capa de repositorio, o bien hay otra entidad de "Categorias" que no se menciona
public interface ITodoListRepository
{
int GetNextId();
List<string> GetAllCategories();
}
-El siguiente método no debería de contener el id de creación del item, tampoco tiene sentido
void AddItem(int id, string title, string description, string category);

-CRUD en controller
-Testing
	*Ejemplo con Mock, y de integracion, happy path y error