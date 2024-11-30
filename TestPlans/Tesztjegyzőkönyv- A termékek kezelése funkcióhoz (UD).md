### 8.3.14. Tesztelési dokumentum a termékkezelés funkciókhoz

---

Az alábbi tesztdokumentum a `2024_IB153l-13_D` projekthez tartozó `8.3.4.2 Termékek kezelése (UD)` funkcióhoz készült. Felelőse: `Farkas Dominika Eliza`


### 1. Teszteljárások (TP)

---

### 1.1. Termék szerkesztése funkció tesztelése

---

* Azonosító: TP-01
* Tesztesetek: TC-01, TC-02, TC-03, TC-04
* Leírás: Termék szerkesztése funkció tesztelése
       0. lépés: Nyissuk meg az alkalmazást, lépjünk be egy admin/chef felhasználóval és menjünk a `Chef page` oldalra, és válasszuk ki a szerkesztésre kijelölt terméket, nyomjuk meg az `Edit` gombot.
       1. lépés: Az `Name` mezőbe írjuk be a termék új nevét.
       2. lépés: Az `Description` mezőbe írjuk be az új jellemzőjét.
       3. lépés: Az `Price` mezőbe írjuk be a termék új árát.
       4. lépés: Nyomjuk meg a `Save` gombot.
       3. lépés: Ellenőrizzük az eredményt. Elvárt eredmény: a termék adatai frissülnek a listában


### 1.2. Termék törlése funkció tesztelése

---

* Azonosító: TP-02
* Tesztesetek: TC-01
* Leírás: Termék törlése funkció tesztelése
       0. lépés: Nyissuk meg az alkalmazást, lépjünk be egy admin/chef felhasználóval és menjünk a `Chef page` oldalra, és válasszunk ki egy törölni kívánt terméket.
       1. lépés: Válasszuk ki a `Delete` gombot a kijelölt terméknél.
       2. lépés: Erősítsük meg a törlést a `Delete` gomb kiválasztásával.
       3. lépés: Ellenőrizzük az eredményt. Elvárt eredmény: a termék eltűnik a terméklistából.



### 2. Tesztesetek (TC)

---

### 2.1. Termék szerkesztése tesztesete

---

### 2.1.1. TC-01

* TP: TP-01
* Leírás: Termék árának módosítása (sikeres eset)
* Bemenet: `Name`=`bread`, `Description`=`Ez egy kenyér`,  `Price` = `650`, `ImageUrl`=`bread-normal`
* Művelet: Módosítsuk a `Price` értéket 700-ra. Nyomjuk meg a `Save` gombot.
* Elvárt kimenet: A terméklistában a régi ár helyett `700` jelenik meg.


### 2.1.2. TC-02

* TP: TP-01
* Leírás: Termék nevének módosítása, úgy hogy kitöröljük az eredeti nevet és üresen hagyjuk (rossz eset)
* Bemenet: `Name`=`bread`, `Description`=`Ez egy kenyér`,  `Price` = `650`, `ImageUrl`=`bread-normal` 
* Művelet: Töröljük ki a termék nevét, és hagyjuk üresen. Nyomjuk meg a `Save` gombot.
* Elvárt kimenet: Hibaüzenet a `Name` mező alatt: `The Name field is required.`


### 2.1.3. TC-03

* TP: TP-01
* Leírás: Termék nevének, árának módosítása, úgy, hogy kitöröljük az eredeti nevet, és az árat is üresen hagyjuk (rossz eset)
* Bemenet: ` Name`=`bread`, `Description`=`Ez egy kenyér`,  `Price` = `650`, `ImageUrl`=`bread-normal`        
* Művelet: Módosítsuk a `Price` értéket és a` Name`, termék nevét üres mezőkre. Nyomjuk meg a `Save` gombot.
* Elvárt kimenet: Hibaüzenet a `Name` mező alatt: `The Name field is required.`  A `Price` mező alatt :`The Price field is required.`



### 2.1.4. TC-04

* TP: TP-01
* Leírás: Termék leírásának módosítása (sikeres eset)
* Bemenet: `Name`=`bread`, `Description`=`Ez egy kenyér`,  `Price` = `650`, `ImageUrl`=`bread-normal`         
* Művelet: Módosítsuk a Description mezőt: `Ez egy nagyon finom kenyér.`  Nyomjuk meg a `Save` gombot.
* Elvárt kimenet: A terméklistában megjelenik az új jellemző.





### 2.2. Termék törlése tesztesete

---

### 2.2.1. TC-01

* TP: TP-02
* Leírás: Termék törlésének tesztelése (sikeres eset)
* Bemenet: Kijelölt alapanyag: `bread`
* Művelet: Nyomjuk meg a `Delete` gombot. Ezután megjelenik az alábbi üzenet: `Are you sure you want to delete this?`. Megnyomjuk a `Delete` gombot.
* Elvárt kimenet: A terméklistában a `bread` termék már nem látható.

