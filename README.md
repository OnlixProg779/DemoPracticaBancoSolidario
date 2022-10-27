# DemoPracticaBancoSolidario

Backend desarrollado con .NET 6 (Multiplataforma)
Estructura de N capas.
Arquitectura Limipa.

Algunas Caracterisiticas:

Proyecto Multicapa con microservicios
- Se Usa: .Net 6 (Multiplataforma)

Microservicio Clientes:
Entidad clientes:
	- Crear Operacion de consultar uno y varios. OK. **********
	- Ingresar varios registros automaticamente desde una clase seedData directo a la persistencia. Ok. ******
	- Validar q la cedula tenga 10 digitos y los campos de cliente no puedan estar vacios ok ***********

Microservicio Nuevo Plan De Ahorro
(Contiene 2 entidades <PlanAhorro> <TiempoPlanDeAhorro> con relacion de uno a muchos) OK.***********
Entidad Nuevo Plan de ahorro
Condiciones: 
	- Minimo para aperturar: $100 OK *********
	- Se paga un interes nominal del 3% anual Ok **********
	- Implementar Create OK.***********
	- Crear Operacion de consultar uno y varios. OK.**************
	- Implementar Consulta (proyeccion a un año con el interes indicado <Presentar la cuenta mensual a 1 año>) Ok *******

Entidad Tiempo plan de ahorro (Para cumplir con principios SOLID) OK ********
	- Autorellenada con un seedData Ok.***********
	- Crear Operacion de consultar uno y varios. OK.************


Generar solucion multicapas OK. ***********

Tecnologias implementadas:
SQL SERVER
.NET CORE
MICROSERVICIOS CON API REST
Implementacion de servicios. Ok *****
Implementacion de contratos. Ok *****
Patrones de diseño. Ok ****
Servicio para Cache header Ok *****
Code first Ok *****
fuent api Ok *****
migrations Ok *****
patron repository Ok *****
patron unit of work Ok *****
patron CQRS con mediaTr Ok *****
Mapper Ok *****
Patron Specification Ok *****
Fluent Validation Ok *****
