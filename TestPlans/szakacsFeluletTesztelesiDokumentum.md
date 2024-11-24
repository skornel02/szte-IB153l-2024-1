## 8.3.15. Tesztelési dokumentáció a szakács felülethez (tesztjegyzőkönyv)

---

Az alábbi tesztdokumentum a `2024_IB153l-13_D` projekthez tartozó `8.3.6. Szakács felület elkészítése (RU)` funkcióhoz készült. Felelőse: `Vass Kinga`

### 1. Teszteljárások (TP)

---

#### 1.1. Szakács felület tesztelése

---

* Azonosító: TP-01
* Tesztesetek: TC-01, TC-02, TC-03
* Leírás: Szakács felület tesztelése.
  * Indítsuk el az alkalmazást, lépjünk be egy admin vagy baker felhasználóval és menjünk a Baker Page oldalra.
  * Válasszunk ki egy terméket és a `Number of products` input mezőbe írjuk be, hogy hány darab készül belőle.
  * Nyomjuk meg a `Make product(s)` gombot.
  * Ellenőrizzük az eredményt. Elvárt eredmény:  
    * Ha egy darab termékhez sincs elég hozzávaló, a gomb kikapcsolt állapotban van, nem lehet elkészíteni a terméket.
    * Egyébként maximum annyit enged elkészíteni, amennyihez van elég hozzávaló. Hozzáadja a megfelelő mennyiségű terméket az `in stock`-hoz és levonja a megfelelő számú hozzávalót. A maximum elkészíthető termékek számát csökkenti megfelelő számmal.

### 2. Tesztesetek (TC)

---

#### 2.1. Szakács felület tesztesetei 

---

#### 2.1.1 TC-01

* TP: TP-01
* Leírás: Szakács felület tesztelése elég hozzávaló esetén
* Választott termék: Pain au chocolat; `in stock`: 12
* Hozzávalók: Liszt (g): 120 | in stock: 99998309
* `Max`: 833319 pcs
* Bemenet: `Number of products` = 2
* Művelet: nyomjuk meg a `Make product(s)` gombot.
* Elvárt kimenet: `in stock`: 14; Liszt (g): 120 | in stock: 99998069; `Max`: 833317 pcs

#### 2.1.2 TC-02

* TP: TP-01
* Leírás: Szakács felület tesztelése kevés hozzávaló esetén
* Választott termék: Pain au chocolat; `in stock`: 14
* Hozzávalók:  Liszt (g): 120 | in stock: 99998069
* `Max`: 833317 pcs
* Bemenet: `Number of products` = 999999
* Művelet: nyomjuk meg a `Make product(s)` gombot.
* Elvárt kimenet: `in stock`: 14; Liszt (g): 120 | in stock: 99998069; hibaüzenet: "Please enter a value less than or equal to 833317."

#### 2.1.3 TC-03

* TP: TP-01
* Leírás: Szakács felület tesztelése egy termékhez is kevés hozzávaló esetén
* Választott termék: Croissant; `in stock`: 16
* Hozzávalók: Liszt (g): 11 | in stock: 99998069
              Tej (dl): 1 | in stock: 277
              Tojás (db): 3 | in stock: 0
* `Max`: 0 pcs
* Bemenet: `Number of products` = 1
* Művelet: nyomjuk meg a `Make product(s)` gombot.
* Elvárt kimenet: a `Make product(s)` gomb ki van kapcsolva, így nem lehet megnyomni; hibaüzenet: "There is not enough ingredients!"


### 3. Tesztriportok (TR)

---

#### 3.1. Szakács felület tesztriportjai

#### 3.1.1. TR-01 (TC-01)

* TP: TP-01
  * 2-t beírtam
  * a gombot megnyomtam
  * `in stock` 14 lett; az Liszt (g) maradt 120, a Liszt in stock 99998069 lett
  * helyes eredményt kaptam

#### 3.1.2. TR-02 (TC-02)

* TP: TP-01
  * 999999-t beírtam
  * a gombot megnyomtam
  * minden maradt, amennyi volt, a hibaüzenet: Please enter a value less than or equal to 833317.
  * helyes eredményt kaptam

#### 3.1.3. TR-03 (TC-03)

* TP: TP-01
    * 1-t beírtam
    * a gombot megnyomtam
    * a gombot nem lehet megnyomni, mert ki van kapcsolva, a hibaüzenet: There is not enough ingredients!
    * helyes eredményt kaptam