public interface IAlmacenRecursos {

	TipoRecursos[] RecursosAceptados{
		get;
	}

	void RecibirRecurso(int cantidad, TipoRecursos recurso);
	bool RecursoValido(TipoRecursos recurso);
}
