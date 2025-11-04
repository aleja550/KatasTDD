# Principios de Encapsulamiento - Hernán Wilkinson

> Basado en el Micro-Workshop: Encapsulamiento de Hernán Wilkinson

## Índice
1. [Qué es el Encapsulamiento](#qué-es-el-encapsulamiento)
2. [Los 5 Principios Fundamentales](#los-5-principios-fundamentales)
3. [Aplicación en Katas](#aplicación-en-katas)
4. [Anti-patrones Comunes](#anti-patrones-comunes)
5. [Checklist de Diseño](#checklist-de-diseño)

---

## Qué es el Encapsulamiento

**El encapsulamiento NO es simplemente "esconder datos"**

Es un **principio de diseño comunicativo** que:
- ✅ Organiza responsabilidades para que los objetos gestionen su propio estado
- ✅ Reduce acoplamiento definiendo fronteras claras entre objetos
- ✅ Protege invariantes mediante mecanismos autocontenidos
- ✅ Permite evolución sin reescribir código existente (Open/Closed Principle)

### Diferencia Clave

| ❌ Ocultación de Información | ✅ Encapsulamiento |
|------------------------------|-------------------|
| `private int saldo;` | El objeto `Cuenta` gestiona sus propias validaciones de retiro |
| `public void setSaldo(int s)` | `cuenta.Retirar(monto)` - la lógica está dentro |
| Otros objetos validan reglas | Las reglas viven dentro del objeto responsable |

---

## Los 5 Principios Fundamentales

### 1. **Encapsulamiento ≠ Ocultación de Información**

**Por qué importa:** El encapsulamiento organiza responsabilidades, no solo esconde datos.

**Ejemplo práctico:**
```csharp
// ❌ MAL - Validaciones fuera del objeto
public class TarjetaCredito
{
    public string Numero { get; set; }
    public DateTime Vencimiento { get; set; }
}

public class ProcesadorPago
{
    public void Procesar(TarjetaCredito tarjeta)
    {
        // Validación en el lugar equivocado
        if (tarjeta.Vencimiento < DateTime.Now)
            throw new Exception("Tarjeta vencida");
    }
}

// ✅ BIEN - Validaciones internas
public class TarjetaCredito
{
    private readonly string _numero;
    private readonly DateTime _vencimiento;

    private TarjetaCredito(string numero, DateTime vencimiento)
    {
        _numero = numero;
        _vencimiento = vencimiento;
    }

    public static TarjetaCredito Crear(string numero, DateTime vencimiento)
    {
        if (vencimiento < DateTime.Now)
            throw new ArgumentException("La tarjeta está vencida");

        return new TarjetaCredito(numero, vencimiento);
    }

    public bool EstaVigente() => _vencimiento >= DateTime.Now;
}
```

---

### 2. **Extensibilidad sin Romper Responsabilidades**

**Problema común:** Al heredar clases, se modifican comportamientos base, generando acoplamiento.

**Solución:** Diseñar objetos que permitan extender funcionalidades sin violar su responsabilidad original.

**Ejemplo práctico:**
```csharp
// ❌ MAL - Herencia que rompe responsabilidades
public class Calendario
{
    public virtual DateTime ObtenerFecha() => DateTime.Now;
}

public class CalendarioNavidad : Calendario
{
    public override DateTime ObtenerFecha()
    {
        // Cambia el comportamiento base de manera confusa
        return new DateTime(DateTime.Now.Year, 12, 25);
    }
}

// ✅ BIEN - Composición y Strategy Pattern
public interface IProveedorFecha
{
    DateTime ObtenerFecha();
}

public class ProveedorFechaActual : IProveedorFecha
{
    public DateTime ObtenerFecha() => DateTime.Now;
}

public class ProveedorFechaFija : IProveedorFecha
{
    private readonly DateTime _fecha;

    public ProveedorFechaFija(DateTime fecha) => _fecha = fecha;

    public DateTime ObtenerFecha() => _fecha;
}

public class Calendario
{
    private readonly IProveedorFecha _proveedorFecha;

    public Calendario(IProveedorFecha proveedorFecha)
    {
        _proveedorFecha = proveedorFecha;
    }

    public DateTime FechaActual => _proveedorFecha.ObtenerFecha();
}
```

---

### 3. **Modelado con Integridad**

**Caso crítico:** Campos opcionales deben manejarse sin exponer lógica interna.

**Técnica clave:** Usar métodos factory que garanticen invariantes en lugar de setters públicos.

**Ejemplo práctico:**
```csharp
// ❌ MAL - Setters públicos permiten estados inválidos
public class Cliente
{
    public string Nombre { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }

    // ¿Cómo garantizamos que tiene al menos un medio de contacto?
}

// ✅ BIEN - Factory methods que garantizan invariantes
public class Cliente
{
    private readonly string _nombre;
    private readonly string? _direccion;
    private readonly string? _telefono;

    private Cliente(string nombre, string? direccion, string? telefono)
    {
        _nombre = nombre;
        _direccion = direccion;
        _telefono = telefono;
    }

    public static Cliente CrearConDireccion(string nombre, string direccion)
    {
        if (string.IsNullOrWhiteSpace(direccion))
            throw new ArgumentException("La dirección no puede estar vacía");

        return new Cliente(nombre, direccion, null);
    }

    public static Cliente CrearConTelefono(string nombre, string telefono)
    {
        if (string.IsNullOrWhiteSpace(telefono))
            throw new ArgumentException("El teléfono no puede estar vacío");

        return new Cliente(nombre, null, telefono);
    }

    public static Cliente CrearConContactoCompleto(string nombre, string direccion, string telefono)
    {
        if (string.IsNullOrWhiteSpace(direccion) || string.IsNullOrWhiteSpace(telefono))
            throw new ArgumentException("Ambos contactos son requeridos");

        return new Cliente(nombre, direccion, telefono);
    }

    public bool TieneDireccion() => !string.IsNullOrWhiteSpace(_direccion);
    public bool TieneTelefono() => !string.IsNullOrWhiteSpace(_telefono);
}
```

---

### 4. **Abstracciones con Nombres Significativos**

**Refactorización estratégica:** Los nombres deben reflejar el propósito real del objeto.

**Ejemplo práctico:**
```csharp
// ❌ MAL - Nombre genérico que oculta responsabilidad
public class Fecha
{
    // ¿Qué calendario usa? ¿Juliano? ¿Gregoriano? ¿Hebreo?
}

// ✅ BIEN - Nombre que comunica el propósito
public class CalendarioGregoriano
{
    private readonly DateTime _fecha;

    public CalendarioGregoriano(int año, int mes, int dia)
    {
        _fecha = new DateTime(año, mes, dia);
    }

    public int Año => _fecha.Year;
    public int Mes => _fecha.Month;
    public int Dia => _fecha.Day;

    public bool EsBisiesto() => DateTime.IsLeapYear(_fecha.Year);
}

// Para números romanos
public class NumeroRomano
{
    private readonly string _representacion;

    private NumeroRomano(string representacion)
    {
        _representacion = representacion;
    }

    public static NumeroRomano DesdeDecimal(int valor)
    {
        // La conversión está encapsulada
        // El objeto garantiza que siempre es válido
    }

    public override string ToString() => _representacion;
}
```

---

### 5. **Lenguajes y Herramientas Flexibles**

**Insight clave:** Algunos lenguajes limitan la extensión (Java con `GregorianCalendar`), otros permiten ajustar modelos sin romper encapsulamiento.

**Lección:** Elegir herramientas que faciliten evolución del código sin sacrificar cohesión.

**En C#:**
- ✅ Usa `sealed` para clases que no deben heredarse
- ✅ Prefiere composición sobre herencia
- ✅ Usa interfaces para definir contratos
- ✅ Usa constructores privados + factory methods para controlar creación

---

## Aplicación en Katas

### Kata: Números Romanos

**Aplicando los principios:**

```csharp
// ✅ BIEN - Encapsulamiento correcto
public class NumeroRomano
{
    private readonly string _representacion;
    private readonly int _valorDecimal;

    // Constructor privado - control total de creación
    private NumeroRomano(int valorDecimal, string representacion)
    {
        _valorDecimal = valorDecimal;
        _representacion = representacion;
    }

    // Factory method - garantiza invariantes
    public static NumeroRomano DesdeDecimal(int valor)
    {
        if (valor <= 0 || valor > 3999)
            throw new ArgumentException("El valor debe estar entre 1 y 3999");

        return new NumeroRomano(valor, ConvertirARomano(valor));
    }

    // Factory method alternativo
    public static NumeroRomano DesdeRomano(string romano)
    {
        ValidarFormatoRomano(romano);
        return new NumeroRomano(ConvertirADecimal(romano), romano);
    }

    // La lógica de conversión está encapsulada
    private static string ConvertirARomano(int valor)
    {
        // Lógica de conversión aquí
    }

    private static int ConvertirADecimal(string romano)
    {
        // Lógica de conversión aquí
    }

    private static void ValidarFormatoRomano(string romano)
    {
        // Validaciones aquí
    }

    // Comportamientos del objeto
    public NumeroRomano Sumar(NumeroRomano otro)
    {
        return DesdeDecimal(_valorDecimal + otro._valorDecimal);
    }

    public bool EsMayorQue(NumeroRomano otro)
    {
        return _valorDecimal > otro._valorDecimal;
    }

    public override string ToString() => _representacion;

    public int ValorDecimal => _valorDecimal;
}
```

**Ventajas de este diseño:**
1. ✅ **Inmutable** - No puede cambiar después de creado
2. ✅ **Garantiza invariantes** - Siempre válido
3. ✅ **Nombres significativos** - Comunica claramente su propósito
4. ✅ **Comportamiento encapsulado** - Puede sumarse, compararse, etc.
5. ✅ **Extensible** - Fácil agregar operaciones sin romper existentes

---

## Anti-patrones Comunes

### ❌ 1. Anemic Domain Model
```csharp
// Solo datos, sin comportamiento
public class NumeroRomano
{
    public string Valor { get; set; }
    public int ValorDecimal { get; set; }
}

public class ConversorRomano
{
    public string Convertir(int numero) { ... }
}
```

**Problema:** El comportamiento está fuera del objeto que debería tenerlo.

---

### ❌ 2. Setters Públicos sin Validación
```csharp
public class NumeroRomano
{
    public string Valor { get; set; }  // ¿Qué pasa si ponen "ABC"?
}
```

**Problema:** No garantiza invariantes.

---

### ❌ 3. Validaciones en el Cliente
```csharp
var numero = new NumeroRomano();
if (valor > 0 && valor < 4000)  // ❌ Validación en lugar equivocado
{
    numero.Valor = ConvertirARomano(valor);
}
```

**Problema:** Cada cliente debe repetir la validación.

---

## Checklist de Diseño

Al diseñar una clase, pregúntate:

### ✅ Responsabilidad
- [ ] ¿El objeto gestiona su propio estado?
- [ ] ¿Las validaciones están dentro del objeto?
- [ ] ¿El comportamiento está donde corresponde?

### ✅ Inmutabilidad
- [ ] ¿Los campos son `readonly`?
- [ ] ¿Hay setters públicos innecesarios?
- [ ] ¿Se puede crear en estado inválido?

### ✅ Creación Controlada
- [ ] ¿Uso factory methods en lugar de constructores públicos?
- [ ] ¿Los factory methods validan invariantes?
- [ ] ¿Los nombres de los factory methods son descriptivos?

### ✅ Nombres Significativos
- [ ] ¿El nombre refleja la responsabilidad real?
- [ ] ¿Los métodos comunican intención claramente?
- [ ] ¿Evito nombres genéricos como "Manager", "Helper"?

### ✅ Extensibilidad
- [ ] ¿Puedo agregar funcionalidad sin modificar código existente?
- [ ] ¿Uso composición en lugar de herencia cuando es posible?
- [ ] ¿Las interfaces definen contratos claros?

---

## Conclusión

El encapsulamiento bien aplicado resulta en:

1. **Código más confiable** - Los objetos siempre están en estado válido
2. **Menos bugs** - Las validaciones no se olvidan
3. **Mejor comunicación** - El diseño se explica solo
4. **Mantenibilidad** - Cambios localizados en un solo lugar
5. **Testabilidad** - Objetos independientes y predecibles

---

## Referencias

- Video original: [Micro-Workshop: Encapsulamiento - Hernán Wilkinson](https://www.youtube.com/watch?v=VEJa7xVfRj4)
- Principios relacionados:
  - Single Responsibility Principle (SRP)
  - Open/Closed Principle (OCP)
  - Tell, Don't Ask
  - Information Expert (GRASP)
