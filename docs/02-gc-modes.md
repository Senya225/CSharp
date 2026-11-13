# КТ №41. Сравнение Workstation и Server GC

## Параметры эксперимента
- Потоков: 4
- Объектов на поток: 300 000
- Размер объекта: byte[100_000] (LOH)
- Сборка: Release

## Результаты замеров

### 1. Условие: На ПК ничего не запущено

**Workstation GC:**
```text
ТЕКУЩИЙ РЕЖИМ: WORKSTATION GC
Server GC: False
Latency mode: Interactive
Принудительный блокирующий Gen2: 0,16 мс
Время: 4137,00 мс
Gen0: 37499, Gen1: 37499, Gen2: 37499
Аллоцировано: 114490,71 МБ
Контрольная сумма: 152985664

Server GC:
ТЕКУЩИЙ РЕЖИМ: SERVER GC
Server GC: True
Latency mode: Interactive
Принудительный блокирующий Gen2: 0,45 мс
Время: 33824,74 мс
Gen0: 3041, Gen1: 3041, Gen2: 3041
Аллоцировано: 114462,19 МБ
Контрольная сумма: 152985664
Workstation GC:
ТЕКУЩИЙ РЕЖИМ: WORKSTATION GC
Server GC: False
Latency mode: Interactive
Принудительный блокирующий Gen2: 0,11 мс
Время: 4263,19 мс
Gen0: 37499, Gen1: 37499, Gen2: 37499
Аллоцировано: 114490,71 МБ
Контрольная сумма: 152985664

Server GC:
ТЕКУЩИЙ РЕЖИМ: SERVER GC
Server GC: True
Latency mode: Interactive
Принудительный блокирующий Gen2: 0,31 мс
Время: 33321,65 мс
Gen0: 3116, Gen1: 3116, Gen2: 3116
Аллоцировано: 114462,70 МБ
Контрольная сумма: 152985664

Workstation GC:
ТЕКУЩИЙ РЕЖИМ: WORKSTATION GC
Server GC: False
Latency mode: Interactive
Принудительный блокирующий Gen2: 0,10 мс
Время: 4080,54 мс
Gen0: 37499, Gen1: 37499, Gen2: 37499
Аллоцировано: 114490,71 МБ
Контрольная сумма: 152985664

Server GC:
ТЕКУЩИЙ РЕЖИМ: SERVER GC
Server GC: True
Latency mode: Interactive
Принудительный блокирующий Gen2: 0,30 мс
Время: 33321,65 мс
Gen0: 3116, Gen1: 3116, Gen2: 3116
Аллоцировано: 114462,70 МБ
Контрольная сумма: 152985664
