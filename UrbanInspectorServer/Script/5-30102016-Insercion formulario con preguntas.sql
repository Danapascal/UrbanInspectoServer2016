/*Scrip para insertar un formulario con preguntas y posibles respuestas*/
/*Formulario*/
INSERT INTO formulario (formularioid, nombre, fechaalta)
VALUES (0, 'Formulario Unico', '29/10/2016 00:00:00.000');

/*Preguntas*/
INSERT INTO pregunta (preguntaid, formularioid, tipoid, texto)
VALUES (0, 0, 0, 'Ingrese la calle e intersecciones');
INSERT INTO pregunta (preguntaid, formularioid, tipoid, texto)
VALUES (1, 0, 1, 'Imperfecciones visibles');
INSERT INTO pregunta (preguntaid, formularioid, tipoid, texto)
VALUES (2, 0, 2, 'Cantidad de baches profundos');
INSERT INTO pregunta (preguntaid, formularioid, tipoid, texto)
VALUES (3, 0, 3, '¿Se observan cables colgando?');

/*Posibles respuestas*/
INSERT INTO posiblerespuesta (posiblerespuestaid, preguntaid, texto)
VALUES (0, 1, 'Baches');
INSERT INTO posiblerespuesta (posiblerespuestaid, preguntaid, texto)
VALUES (1, 1, 'Rotura de cordon');
INSERT INTO posiblerespuesta (posiblerespuestaid, preguntaid, texto)
VALUES (2, 1, 'Ramas');
INSERT INTO posiblerespuesta (posiblerespuestaid, preguntaid, texto)
VALUES (3, 1, 'Cables bajos');
INSERT INTO posiblerespuesta (posiblerespuestaid, preguntaid, texto)
VALUES (4, 2, '1');
INSERT INTO posiblerespuesta (posiblerespuestaid, preguntaid, texto)
VALUES (5, 2, '2');
INSERT INTO posiblerespuesta (posiblerespuestaid, preguntaid, texto)
VALUES (6, 2, '3');
INSERT INTO posiblerespuesta (posiblerespuestaid, preguntaid, texto)
VALUES (7, 2, '4');
INSERT INTO posiblerespuesta (posiblerespuestaid, preguntaid, texto)
VALUES (8, 3, 'Si');
INSERT INTO posiblerespuesta (posiblerespuestaid, preguntaid, texto)
VALUES (9, 3, 'No');