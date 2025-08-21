# Calculo-de-PLRC
Aulas Práticas: Problema Gerador : Cálculo de PLR


entradas: 
    - SALÁRIO 
    - LUCRO_LIQUIDO 
    - tx lucro, 
    - #colaboradores
    - %IR

regras: 
    - Regra Básica: = SALÁRIO * 0.9 + 3343.04 (limitado ao teto de R$ 17.933,79). 
    - Parcela Adicional: = LUCRO_LIQUIDO * 0.022 (limitado ao teto de R$ 6.942,28). 
    - PLR Social: = LUCRO_LIQUIDO * 0.04 (distribuído linearmente). 
    - Total PLR: = Regra_Básica + Parcela_Adicional + PLR_Social. 
    - IR: Utilize uma tabela ou função para calcular o imposto sobre a PLR, considerando a tabela vigente. 
    - PLR Líquido: = Total_PLR - IR

saidas: Relatorio
    - PLR Líquido
    - IR
    - Total PLR
    - PLR Social
    - Parcela Adicional
