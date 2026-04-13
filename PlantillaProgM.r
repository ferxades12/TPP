library(lpSolve)

# 1. Definición de parámetros del problema

# Coeficientes de la función objetivo
# Representan el beneficio o coste unitario de cada variable.
coef <- c(940, 1220, 560, 760)

# Matriz de coeficientes tecnológicos 
A <- rbind(c(1,0,1,0),
           c(0,1,0,1),
           c(3,4,2,2),
           c(1,1,0,0),
           c(0,0,1,1))

# Dirección de las restricciones
dir <- rep("<=", 5)

# Términos independientes
b <- c(900,900,4000,1000,800)

# compute.sens = TRUE 
sol <- lp(direction = "max", 
          objective.in = coef, 
          const.mat = A, 
          const.dir = dir, 
          const.rhs = b, 
          compute.sens = TRUE)

# Valor óptimo de la función objetivo
sol$objval 

# Valores de las variables de decisión en el óptim
# Si el valor es > 0, es una variable básica 
sol$solution 


# Rangos entre los que pueden variar los coeficientes sin que cambie la base óptima
sol$sens.coef.from # Límite inferior 
sol$sens.coef.to   # Límite superior

# Costes reducidos (últimos n elementos de sol$duals)
# Significado: 
# 1. Si la variable es no básica, indica cuánto debe mejorar su coeficiente 
#    para que sea rentable entrar en la base
# 2. Es la cantidad máxima que se puede modificar el coeficiente sin cambiar 
#    la solución óptima
n_vars <- length(coef)
sol$duals[(length(sol$duals) - n_vars + 1):length(sol$duals)]

# Holguras de las restricciones
# Valor = 0: Restricción saturada (recurso escaso)
# Valor > 0: Restricción con sobrante (no condiciona el óptimo de forma directa)
round(abs(A %*% sol$solution - b), 4)

# Precios sombra (primeros m elementos de sol$duals)
# Significado: Aumento del valor de la función objetivo por cada unidad adicional del recurso.
# Es el precio máximo a pagar por una unidad extra del recurso
m_restr <- length(b)
psombra = sol$duals[1:m_restr]

# Rangos de variación de los recursos (b) 
# Intervalos donde el precio sombra es válido
sol$duals.from[1:m_restr] # Límite inferior 
sol$duals.to[1:m_restr]   # Límite superior 

# Cálculo de nueva función objetivo ante cambios en b:
# z_nueva = z_actual + (precio_sombra * cambio_en_recurso)


# Mirar que pasaria si tenemos 4300h de trabajo
b[3]
holguras[3]
psombra[3] # Si aumentasemos las horas ganariamos esto
c(sol$duals.from[3], sol$duals.to[3]) # Mientras estemos en este intervalo
sol$objval + 300 *psombra[3] # Nuevo valor
