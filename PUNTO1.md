# ¿Cuál es la salida del siguiente código?

var list = new[] { 3, -3, 5, 1 };
var sum = 0;
foreach (var item in list)
{
    if (item > 3)
    sum = sum + item;
    else
    sum -= item;
}

A: -4
**B: 4 (RESPUESTA CORRECTA)**
C: 11
D: Syntax Error

# Resualtados de las iteraciones:
- Iteracion 1:
    item = 3     -->     item > 3       -->      sum -= 3       -->     sum = 0 - 3     -->         sum = -3

- Iteracion 2:
    item = -3     -->     item > 3       -->      sum -= -3       -->     sum = -3 + 3     -->         sum = 0

- Iteracion 3:
    item = 5     -->     item > 3       -->      sum = sum + item       -->     sum = 0 + 5     -->         sum = 5

- Iteracion 4:
    **item = 1     -->     item > 3       -->      sum -= 1       -->     sum = 5 - 1     -->         sum = 4**

# RESPUESTA CORRECTA B : 4