/*CREACION DE TABLAS*/
/*Usuario:
	UsuarioId: Integer - Clave primaria
	Nombre: String(50)
	Apellido: String(50)
	Login: String(50)
	Password: String(50)
	Activo: Boolean
	UltimoLogin: DateTime
*/
CREATE TABLE usuario
(
  usuarioid integer NOT NULL,
  nombre character varying(50),
  apellido character varying(50),
  login character varying(50) NOT NULL,
  password character varying(50) NOT NULL,
  activo boolean NOT NULL,
  ultimologin date,
  CONSTRAINT usuario_pk PRIMARY KEY (usuarioid)
)

/*Formulario:
	FormularioId: Integer - Clave primaria
	Nombre: String(50)
	FechaAlta: DateTime
*/
CREATE TABLE formulario
(
  formularioid integer NOT NULL,
  nombre character varying(50),
  fechaalta date NOT NULL,
  CONSTRAINT formulario_pk PRIMARY KEY (formularioid)
)

/*Pregunta:
	PreguntaId: Integer - Clave primaria
	FormularioId: Integer - Clave foranea
	TipoId
	Texto: String(100)
*/
CREATE TABLE pregunta
(
  preguntaid integer NOT NULL,
  formularioid integer NOT NULL,
  tipoid integer NOT NULL,
  texto character varying(100) NOT NULL,
  CONSTRAINT pregunta_pk PRIMARY KEY (preguntaid),
  CONSTRAINT pregunta_formularioid_fk FOREIGN KEY (formularioid) REFERENCES formulario (formularioid)
)
	
/*PosibleRespuesta:
	PosibleRespuestaId: Integer - Clave primaria
	PreguntaId: Integer - Clave foranea
	Texto: String(50)
*/
CREATE TABLE posiblerespuesta
(
  posiblerespuestaid integer NOT NULL,
  preguntaid integer NOT NULL,
  texto character varying(100) NOT NULL,
  CONSTRAINT posiblerespuesta_pk PRIMARY KEY (posiblerespuestaid),
  CONSTRAINT posiblerespuesta_preguntaid_fk FOREIGN KEY (preguntaid) REFERENCES pregunta (preguntaid) )

/*FormularioRespondido:
	FormularioRespondidoId: Integer - Clave primaria
	FormularioId: Integer - Clave foranea
	UsuarioId: Integer - Clave foranea
	Fecha de alta: Date
	Latitud
	Longitud
*/
CREATE TABLE formulariorespondido
(
  formulariorespondidoid integer NOT NULL,
  formularioid integer NOT NULL,
  usuarioid integer NOT NULL,
  fechaalta date NOT NULL,
  latitud integer,
  longitud integer,
  CONSTRAINT formulariorespondido_pk PRIMARY KEY (formulariorespondidoid),
  CONSTRAINT formulariorespondido_formularioid_fk FOREIGN KEY (formularioid)
  REFERENCES formulario (formularioid),
  CONSTRAINT "usuarioId" FOREIGN KEY (usuarioid) REFERENCES usuario (usuarioid) 
)
	
/*Respuesta:
	RespuestaId: Integer - Clave primaria
	FormularioRespondidoId: Integer - Clave foranea
	PosibleRespuestaId: Integer - Clave foranea
	Texto: String(200)
*/
CREATE TABLE respuesta
(
  respuestaid integer NOT NULL,
  formulariorespondidoid integer NOT NULL,
  posiblerespuestaid integer NOT NULL,
  texto character varying(200) NOT NULL,
  CONSTRAINT respuestaid_pk PRIMARY KEY (respuestaid),
  CONSTRAINT respuesta_formulariorespondidoid_fk FOREIGN KEY (formulariorespondidoid) REFERENCES formulariorespondido (formulariorespondidoid),
  CONSTRAINT respuesta_posiblerespuestaid_fk FOREIGN KEY (posiblerespuestaid) REFERENCES posiblerespuesta (posiblerespuestaid) 
)

/*Tipo:
	TipoId: Integer - Clave primaria
	Nombre: String(50)
*/
CREATE TABLE tipo
(
  tipoid integer NOT NULL,
  nombre character varying(50) NOT NULL,
  CONSTRAINT tipoid_pk PRIMARY KEY (tipoid)
)

/*
Foto:
	FotoId: Integer - Clave primaria
	FormularioRespondidoId: Integer - Clave foranea
	Valor: String(500)
*/
CREATE TABLE foto
(
  fotoid integer NOT NULL,
  formulariorespondidoid integer NOT NULL,
  valor character varying(500),
  CONSTRAINT fotoid_pk PRIMARY KEY (fotoid),
  CONSTRAINT foto_formulariorespondidoid_fk FOREIGN KEY (formulariorespondidoid) REFERENCES formulariorespondido (formulariorespondidoid) 
)

/*
CREATE TABLE FormularioPregunta(
            FormularioId	                 	int 	 	        NOT NULL,
	PreguntaId				int			NOT NULL,
   
	CONSTRAINT PKFormularioPregunta PRIMARY KEY (FormularioId, PreguntaId),
	FOREIGN KEY(FormularioId) REFERENCES Formulario (FormularioId),
	FOREIGN KEY(PreguntaId) REFERENCES Pregunta (PreguntaId)
);
*/

