## 8.3.16. Tesztelési dokumentáció a webshophoz (tesztjegyzőkönyv)

---

Az alábbi tesztdokumentum a `2024_IB153l-13_D` projekthez tartozó `8.3.7. Webshop felület elkészítése (termékek, kosár) (CRU)` és a `8.3.8. Webshop felület elkészítése (adatbekérés, rendelés állapota) (RU)` funkcióhoz készült. Felelőse: `Vass Kinga`

### 1. Teszteljárások (TP)

---

#### 1.1. Webshop tesztelése, kosárba helyezés

---

* Azonosító: TP-01
* Tesztesetek: TC-01, TC-02, TC-03, TC-04
* Leírás: Webshop tesztelése, kosár működése.
  * Indítsuk el az alkalmazást, lépjünk be egy sima webshop user felhasználóval és menjünk a Webshop oldalra.
  * Válasszunk ki egy terméket és az input mezőbe írjuk be, hogy hány darabot szeretnénk venni belőle.
  * Nyomjuk meg az `Add` gombot.
  * Ha többet szeretnénk, mint amennyi van a raktárban, nem fogja engedni.
  * Ellenőrizzük az eredményt. Elvárt eredmény:
    * A fenti kosár ikonra rányomva láthatjuk a betett terméket, a számát és az árat.
    * Ha nincs elég termék a raktárban, nem enged annyit beletenni a kosárba.

#### 1.2. Webshop tesztelése, kosárban lévő termékek megvétele

---

* Azonosító: TP-02
* Tesztesetek: TC-05, TC-06
* Leírás: Webshop tesztelése, kosárban lévő termékek vásárlásának tesztelése.
  * Indítsuk el az alkalmazást, lépjünk be egy sima webshop user felhasználóval és menjünk a Webshop oldalra.
  * Válasszunk ki egy terméket és az input mezőbe írjuk be, hogy hány darabot szeretnénk venni belőle.
  * Nyomjuk meg az `Add` gombot.
  * Nyomjunk rá a kosár gombra.
  * Ha átjutottunk a kosár oldalra, akkor nyomjuk meg a `Submit Order` gombot.
  * Ellenőrizzük az eredményt. Elvárt eredmény:
    * Az `MyOrders` oldalon láthatjuk az imént leadott rendelést.

### 2. Tesztesetek (TC)

---

#### 2.1. Webshop kosár tesztesetei

---

#### 2.1.1. TC-01

* TP: TP-01
* Leírás: Webshop kosár tesztelése, ha üres a kosár
* Választott termék: -
* Bemenet: -
* Művelet: Átmegyünk a `Cart` oldalra
* Elvárt kimenet: 
  * Your cart is empty!

#### 2.1.2. TC-02

* TP: TP-01
* Leírás: Webshop kosár tesztelése egyféle termék vásárlása esetén
* Választott termék: Croissant, 650,00 €
* Bemenet: 2
* Művelet: nyomjuk meg az `Add` gombot.
* Elvárt kimenet: `Cart` oldalon:
  * Termék: Croissant
  * `Qty`: 2 | 1300,00 €
  * `Total`: 1300,00 €

#### 2.1.3. TC-03

* TP: TP-01
* Leírás: Webshop kosár tesztelése többféle termék vásárlása esetén
* Választott termékek: Croissant; Pain au chocolat
* Bemenet: 5; 2
* Művelet: nyomjuk meg az `Add` gombot.
* Elvárt kimenet: `Cart` oldalon:
  * Termék: Croissant
  * `Qty`: 5 | 3250,00 €
  * Termék: Pain au chocolat
  * `Qty`: 2 | 240,00 €
  * `Total`: 3490,00 €

#### 2.1.4. TC-04

* TP: TP-01
* Leírás: Webshop kosár tesztelése kevés raktárban lévő termék vásárlása esetén
* Választott termék: Croissant
* Bemenet: 2000
* Művelet: nyomjuk meg az `Add` gombot.
* Elvárt kimenet:
  * A gomb megnyomására hibaüzenet jön fel (ha a raktárban 20 darab croissant van): "Az érték legyen kisebb vagy egyenlő mint 20."

#### 2.2. Webshop rendelés leadása tesztesetei

---

#### 2.2.1. TC-05

* TP: TP-02
* Leírás: Webshop rendelés leadása és utána a rendelések megtekintésének tesztelése
* Választott termék: Dénes Donut
* Bemenet: 2
* Művelet: nyomjuk meg az `Add` gombot.
* Menjünk át a `Cart` oldalra.
* Nyomjuk meg a `Submit Order` gombot.
* Elvárt kimenet:
  * A gom megnyomására a rendelés mentésre kerül, átirányítanak a `MyOrders` oldalra, ahol látjuk a rendelést:
  * `Product Name`: Dénes Donut
  * `Qantity`: 2
  * `Price`: 199998,00 €
  * `Order Status`: OrderPlaced

#### 2.2.2. TC-06

* TP: TP-02
* Leírás: Webshop rendelés leadása és utána a rendelések megtekintésének tesztelése
* Választott termék: croissant, Pain au chocolat, Dénes Donut
* Bemenet: 2, 2, 2
* Művelet: nyomjuk meg az `Add` gombot.
* Menjünk át a `Cart` oldalra.
* Nyomjuk meg a `Submit Order` gombot.
* Elvárt kimenet:
  * A gom megnyomására a rendelés mentésre kerül, átirányítanak a `MyOrders` oldalra, ahol látjuk a rendelést:
  * `Product Name`: croissant, Pain au chocolat, Dénes Donut
  * `Qantity`: 2, 2, 2 
  * `Price`: 201538,00 €
  * `Order Status`: OrderPlaced

### 3. Tesztriportok (TR)

---

#### 3.1. Webshop tesztriportjai, kosár

#### 3.1.1. TR-01 (TC-01)

* TP: TP-01
  * nem írtam be semmit
  * nem nyomtam meg a gombot
  * a `Cart` oldalra átmentem
  * ez a felirat fogadott: Your cart is empty!
  * helyes eredményt kaptam

#### 3.1.2. TR-02 (TC-02)

* TP: TP-01
  * 2000-t beírtam
  * a gombot megnyomtam
  * a gomb nem működött, hibaüzenet: Az érték legyen kisebb vagy egyenlő mint 20.
  * helyes eredményt kaptam

#### 3.1.3. TR-03 (TC-03)

* TP: TP-01
  * 2-t beírtam
  * a gombot megnyomtam
  * a `Cart` oldalra átmentem
  * egy kártyában: croissant, `Qty`: 2, 1300,00 €
  * `Total`: 1300,00 €
  * helyes eredményt kaptam

#### 3.1.4. TR-04 (TC-04)

* TP: TP-01
  * 5-t beírtam a croissant-hoz
  * 2-t beírtam a pain au chocolat-hoz
  * a gombot megnyomtam
  * a `Cart` oldalra átmentem
  * egy kártyában: croissant, `Qty`: 5,  3250,00 €
  * egy kártyában: pain au chocolat, `Qty`: 2,  240,00 €
  * `Total`: 3490,00 €
  * helyes eredményt kaptam

#### 3.2. Webshop tesztriportjai, fizetés, rendelések

---

#### 3.2.1. TR-05 (TC-05)
* TP: TP-02
  * 2-t beírtam a Dénes Donut-hoz
  * a gombot megnyomtam
  * a `Cart` oldalra átmentem
  * a `Submit Order` gombot megnyomtam
  * Átkerültem a `MyOrders` oldalra
  * egy táblázatban: Dénes Donut, 2, 199998,00 €, OrderPlaced
  * helyes eredményt kaptam

#### 3.2.2. TR-06 (TC-06)
* TP: TP-02
  * 2-t beírtam a croissant-hoz
  * a gombot megnyomtam
  * 2-t beírtam a Pain au chocolat-hoz
  * a gombot megnyomtam
  * 2-t beírtam a Dénes Donut-hoz
  * a gombot megnyomtam
  * a `Cart` oldalra átmentem
  * a `Submit Order` gombot megnyomtam
  * Átkerültem a `MyOrders` oldalra
  * egy táblázatban: croissant, Pain au chocolat, Dénes Donut | 2, 2 2 | 201538,00 € | OrderPlaced
  * helyes eredményt kaptam
