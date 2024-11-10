### 8.3.14. Tesztelési dokumentum a termékkezelés funkciókhoz

---

Az alábbi tesztdokumentum a `2024_IB153l-13_D` projekthez tartozó `8.3.4.2 Termékek kezelése (UD)` funkcióhoz készült. Felelőse: `Farkas Dominika Eliza`


### 1. Teszteljárások (TP)

---

### 1.1. Termék szerkesztése funkció tesztelése

---

* Azonosító: TP-01
* Tesztesetek: TC-01
* Leírás: Termék szerkesztése funkció tesztelése
       0. lépés: Nyissuk meg az alkalmazást, lépjünk be egy admin felhasználóval és menjünk a `Products` oldalra, és válasszuk ki a szerkesztésre kijelölt terméket, nyomjuk meg az `Edit` gombot.
       1. lépés: Az `Name` mezőbe írjuk be a termék nevét.
       2. lépés: Az `Description` mezőbe írjuk be az új jellemzőjét.
       3. lépés: Az `Price` mezőbe írjuk be a termék új árát.
       4. lépés: Nyomjuk meg a `Save` gombot.
       3. lépés: Ellenőrizzük az eredményt. Elvárt eredmény: a termék adatai frissülnek a listában



### 2. Tesztesetek (TC)

---

### 2.1. Termék szerkesztése tesztesetei

---

### 2.1.1. TC-01

* TP: TP-01
* Leírás: Termék árának módosítása (sikeres eset)
* Bemenet: Eredeti  `Price` = 650           Új  `Price` = 700
* Művelet: Nyomjuk meg a `Save` gombot.
* Elvárt kimenet: A terméklistában a régi ár helyett `700` jelenik meg.

