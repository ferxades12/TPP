namespace Clausuras;

using static Clausuras.ForLoopClass;

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ForLoopTests {

    [TestMethod]
    public void ForLoop_EnterosCrecientes_ProduceSecuenciaCorrecta() {
        int i = 0;
        var resultado = new List<int>();

        ForLoop(
            () => i = 0,
            () => i < 5,
            () => i++,
            () => resultado.Add(i)
        );

        CollectionAssert.AreEqual(new[] { 0, 1, 2, 3, 4 }, resultado);
    }

    [TestMethod]
    public void ForLoop_EnterosDecrecientes_ProduceSecuenciaCorrecta() {
        int i = 0;
        var resultado = new List<int>();

        ForLoop(
            () => i = 5,
            () => i > 0,
            () => i--,
            () => resultado.Add(i)
        );

        CollectionAssert.AreEqual(new[] { 5, 4, 3, 2, 1 }, resultado);
    }

    [TestMethod]
    public void ForLoop_ConStrings_AcumulaConcatenacion() {
        int i = 0;
        string acumulado = "";

        ForLoop(
            () => i = 0,
            () => i < 3,
            () => i++,
            () => acumulado += $"item{i} "
        );

        Assert.AreEqual("item0 item1 item2 ", acumulado);
    }

    [TestMethod]
    public void ForLoop_ConDoubles_AcumulaSuma() {
        double d = 0;
        double suma = 0;

        ForLoop(
            () => d = 0.0,
            () => d < 1.0,
            () => d += 0.25,
            () => suma += d
        );

        Assert.AreEqual(1.5, suma, 1e-10);
    }

    [TestMethod]
    public void ForLoop_LlenandoLista_ProduceTamañoCorrecto() {
        int i = 0;
        var lista = new List<string>();

        ForLoop(
            () => i = 0,
            () => i < 100,
            () => i++,
            () => lista.Add($"elemento_{i}")
        );

        Assert.HasCount(100, lista);
        Assert.AreEqual("elemento_0", lista[0]);
        Assert.AreEqual("elemento_99", lista[99]);
    }


    [TestMethod]
    public void ForLoop_CondicionFalsaDesdeElInicio_NuncaEjecuta() {
        int i = 0;
        int ejecutado = 0;

        ForLoop(
            () => i = 10,
            () => i < 5,
            () => i++,
            () => ejecutado++
        );

        Assert.AreEqual(0, ejecutado);
    }

    [TestMethod]
    public void ForLoop_UnaIteracion_EjecutaExactamenteUnaVez() {
        int i = 0;
        int ejecutado = 0;

        ForLoop(
            () => i = 0,
            () => i < 1,
            () => i++,
            () => ejecutado++
        );

        Assert.AreEqual(1, ejecutado);
    }

    [TestMethod]
    public void ForLoop_InitializationSobreescribeValorPrevio() {
        int i = 999;
        var resultado = new List<int>();

        ForLoop(
            () => i = 0,
            () => i < 3,
            () => i++,
            () => resultado.Add(i)
        );

        CollectionAssert.AreEqual(new[] { 0, 1, 2 }, resultado);
    }

    [TestMethod]
    public void ForLoop_LlamadosConsecutivos_CorrectoEnCadaLlamada() {
        int i = 0;
        var primera = new List<int>();
        var segunda = new List<int>();

        ForLoop(() => i = 0, () => i < 3, () => i++, () => primera.Add(i));
        ForLoop(() => i = 0, () => i < 3, () => i++, () => segunda.Add(i));

        CollectionAssert.AreEqual(primera, segunda);
    }

    [TestMethod]
    public void ForLoop_ValoresNegativos_IteraCorrectamente() {
        int i = 0;
        var resultado = new List<int>();

        ForLoop(
            () => i = -3,
            () => i < 0,
            () => i++,
            () => resultado.Add(i)
        );

        CollectionAssert.AreEqual(new[] { -3, -2, -1 }, resultado);
    }

    [TestMethod]
    public void ForLoop_PasoMayorQueUno_SaltaValoresCorrectamente() {
        int i = 0;
        var resultado = new List<int>();

        ForLoop(
            () => i = 0,
            () => i < 10,
            () => i += 3,
            () => resultado.Add(i)
        );

        CollectionAssert.AreEqual(new[] { 0, 3, 6, 9 }, resultado);
    }

    [TestMethod]
    public void ForLoop_ClosureCapturaMismaVariable_ModificacionesSeReflejan() {
        int i = 0;
        int sumaExterna = 0;

        Action init = () => i = 1;
        Func<bool> cond = () => i <= 4;
        Action iter = () => i *= 2;
        Action body = () => sumaExterna += i;

        ForLoop(init, cond, iter, body);

        Assert.AreEqual(7, sumaExterna);
        Assert.AreEqual(8, i);
    }

    [TestMethod]
    public void ForLoop_ClosureModificaListaExterna_ListaContieneResultados() {
        int i = 0;
        var externa = new List<int> { 99 };

        ForLoop(
            () => i = 0,
            () => i < 3,
            () => i++,
            () => externa.Add(i * 10)
        );

        CollectionAssert.AreEqual(new[] { 99, 0, 10, 20 }, externa);
    }

    [TestMethod]
    public void ForLoop_InitializationNula_LanzaExcepcion() {
        int i = 0;
        Assert.Throws<NullReferenceException>(() => ForLoop(null!, () => i < 3, () => i++, () => { }));
    }

    [TestMethod]
    public void ForLoop_ConditionNula_LanzaExcepcion() {
        int i = 0;
        Assert.Throws<NullReferenceException>(() => ForLoop(() => i = 0, null!, () => i++, () => { }));
    }

    [TestMethod]
    public void ForLoop_IterationNula_LanzaExcepcion() {
        int i = 0;
        Assert.Throws<NullReferenceException>(() => ForLoop(() => i = 0, () => i < 3, null!, () => { }));
    }

    [TestMethod]
    public void ForLoop_ActionNula_LanzaExcepcion() {
        int i = 0;
        Assert.Throws<NullReferenceException>(() => ForLoop(() => i = 0, () => i < 3, () => i++, null!));
    }
}