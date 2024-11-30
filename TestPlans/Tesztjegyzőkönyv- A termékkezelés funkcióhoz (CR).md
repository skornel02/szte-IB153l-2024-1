### 8.3.14. Tesztelési dokumentum a termékkezelés funkciókhoz

---

Az alábbi tesztdokumentum a `2024_IB153l-13_D` projekthez tartozó `8.3.4.1 Termékek kezelése (CR)` funkcióhoz készült. Felelőse: `Stefán Kornél`


### 1. Teszteljárások (TP)

---

### 1.1. Termék hozzáadása funkció tesztelése

---

* Azonosító: TP-01
* Tesztesetek: TC-01, TC-02, TC-03, TC-04, TC-05
* Leírás: Termék hozzáadása funkció tesztelése
       0. lépés: Nyissuk meg az alkalmazást, lépjünk be egy admin/chef felhasználóval és menjünk a `Chef page` oldalra, és nyomjuk meg az `Add new product` gombot.
       1. lépés: Az `Name` mezőbe írjuk be a termék nevét.
       2. lépés: Az `Description` mezőbe írjuk be az jellemzőjét.
       3. lépés: Az `Price` mezőbe írjuk be a termék árát.
       4. lépés: Nyomjuk meg a `Create` gombot. 
       5. lépés: Ellenőrizzük az eredményt. Elvárt eredmény: a termék hozzáadása sikeres, és megjelenik az termék listában.



### 2. Tesztesetek (TC)

---

### 2.1. Termék hozzáadása tesztesetei

---

### 2.1.1. TC-01

* TP: TP-01
* Leírás: Termék hozzáadása tesztelése minden adat helyesen van kitöltve(sikeres eset)
* Bemenet: `Name` = `croissant`, `Description` = `honhonhon`, `Price` = 650, `ImageUrl` = `croissant-cocoa`
* Művelet: Nyomjuk meg a `Create` gombot.
* Elvárt kimenet: A terméklistában megjelenik egy új termék: `croissant, honhonhon, 650, croissant-cocoa`.


### 2.1.2. TC-02

* TP: TP-01
* Leírás: Termék hozzáadása tesztelése, termék nevét üresen hagyjuk (rossz eset)
* Bemenet: `Name` = `` (üresen hagyjuk), `Description` = `abcabacabac`, `Price` = 650, `ImageUrl` = `bread`
* Művelet: Nyomjuk meg a `Create` gombot.
* Elvárt kimenet: Hibaüzenet, a `Name` mező alatt: `The Name field is required.`


### 2.1.3. TC-03

* TP: TP-01
* Leírás: Termék hozzáadása tesztelése, az ár helyére negatív számot írunk (rossz eset)
* Bemenet: `Name` = `croissant`,  `Description` = `honhonhon`, `Price` = -1, `ImageUrl` = `croissant-cocoa`
* Művelet: Nyomjuk meg a `Create` gombot.
* Elvárt kimenet: Hibaüzenet, a `Price` mező alatt: `Please enter a value greater than or equal to 0.`


### 2.1.4. TC-04

* TP: TP-01
* Leírás: Termék hozzáadása tesztelése, az ár helyére nem írunk semmit (rossz eset)
* Bemenet: `Name` = `Dénes Donut`,  `Description` = `abcabcabc`, `Price` = ``,  `ImageUrl` = `donut`
* Művelet: Nyomjuk meg a `Create` gombot.
* Elvárt kimenet: Hibaüzenet, a `Price` mező alatt: `The Price field is required.`



### 2.1.5. TC-05

* TP: TP-01
* Leírás: Termék hozzáadása tesztelése, a jellemző helyére nem írunk semmit (sikeres eset)
* Bemenet: `Name` = `bread`, `Description` = ``(üresen hagyjuk), `Price` = 750, `ImageUrl` = `bread`
* Művelet: Nyomjuk meg a `Create` gombot.
* Elvárt kimenet: A terméklistában megjelenik az új termék.

