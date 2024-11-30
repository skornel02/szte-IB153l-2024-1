### 8.3.13. Tesztelési dokumentum az alapanyagkezeléshez

---

Az alábbi tesztdokumentum a `2024_IB153l-13_D` projekthez tartozó `8.3.3. Alapanyagok kezelése (CRUD)` funkcióhoz készült. Felelőse: `Vad Avar`

---


### 1. Teszteljárások (TP)

---

### 1.1. Alapanyag hozzáadása funkció tesztelése

---

* Azonosító: TP-01
* Tesztesetek: TC-01, TC-02, TC-03, TC-04
* Leírás: Alapanyag hozzáadása funkció tesztelése
       0. lépés: Nyissuk meg az alkalmazást, lépjünk be egy admin felhasználóval és menjünk az Ingredients oldalra és nyomjuk meg a `Create ingredient` gombot.
       1. lépés: A `Name` mezőbe írjuk be az alapanyag nevét.
       2. lépés: Az `Stock` mezőbe írjuk be a készlet mennyiség értéket.
       3. lépés: Az `Maximum stock` mezőbe írjuk be a maximum mennyiség értéket.
       4. lépés: Az alapanag létrehozásához nyomjuk meg a `Save` gombot.
       5. lépés: Ellenőrizzük az eredményt. Elvárt eredmény: az alapanyag hozzáadása sikeres, és megjelenik az alapanyag listában.

### 1.2. Alapanyag szerkesztése funkció tesztelése
* Azonosító: TP-02
* Tesztesetek: TC-01, TC-02, TC-03, TC-04, TC-05
* Leírás: Alapanyag szerkesztése funkció tesztelése
       0. lépés: Nyissuk meg az alkalmazást, lépjünk be egy admin felhasználóval és menjünk az Ingredients oldalra, és válasszuk ki a szerkesztésre kijelölt alapanyagot, a "ceruza" ikonra kattintva.
       1. lépés: A `Name` mezőben módosítsuk a nevet az új alapanyag névre.
       2. lépés: A `Stock` mezőben módosítsuk a készletet az új mennyiségre.
       3. lépés: A `Maximum stock` mezőben módosítsuk a maximum mennyiség értéket az új értékre.
       4. lépés: Mentéshez nyomjuk meg a `Save` gombot.
       5. lépés: Ellenőrizzük az eredményt. Elvárt eredmény: a alapanyag adatai frissülnek a listában.

### 1.3. Alapanyag törlése funkció tesztelése
* Azonosító: TP-03
* Tesztesetek: TC-01
* Leírás: Alapanyag törlése funkció tesztelése
       0. lépés: Nyissuk meg az alkalmazást, lépjünk be egy admin felhasználóval és menjünk az Ingredients oldalra, és válasszunk ki egy törölni kívánt alapanyagot.
       1. lépés: Válasszuk ki a `Kuka` gombot a kijelölt alapanyagnál.
       2. lépés: Erősítsük meg a törlést a `Delete` gomb kiválasztásával.
       3. lépés: Ellenőrizzük az eredményt. Elvárt eredmény: a alapanyag eltűnik a alapanyaglistából.

### 2. Tesztesetek (TC)

---

### 2.1. Alapanyag hozzáadása tesztesetei

---

### 2.1.1. TC-01

* TP: TP-01
* Leírás: Alapanyag hozzáadása tesztelése, a készlet üresen hagyjuk (hiányzó adat)
* Bemenet: `Name` = `Egg (pcs)`, `Stock` =``, `Maximum stock` = 100
* Művelet: Nyomjuk meg a `Create` gombot.
* Elvárt kimenet: Stock mezőnél megjelenik az alábbi üzenet: `The Stock field is required.`

### 2.1.2. TC-02
* TP: TP-01
* Leírás: Alapanyag hozzáadása tesztelése (sikeres eset)
* Bemenet: `Name` = `Milk (dl)`, `Stock` = 300, `Maximum stock` = `500`
* Művelet: Nyomjuk meg a `Create` gombot.
* Elvárt kimenet: Az alapanyagok listában megjelenik egy új alapanyag: `Milk (dl), 300, 500`.


### 2.1.3. TC-03
* TP: TP-01
* Leírás: Alapanyag hozzáadása tesztelése, alapanyag nevét üresen hagyjuk (rossz eset)
* Bemenet: `Name` = ``,  `Stock` = `300`, `Maximum stock` = `500`
* Művelet: Nyomjuk meg a `Create` gombot.
* Elvárt kimenet: A `Name` mező alatt megjelenik az alábbi hibaüzenet: `The Name field is required.`



### 2.1.4. TC-04
* TP: TP-01
* Leírás: Alapanyag hozzáadása tesztelése, a maximális készlet értéket üresen hagyjuk (hiányzó adat)
* Bemenet: `Name` = `Egg (pcs)`, Stock =`50`, `Maximum stock` = ``
* Művelet: Nyomjuk meg a `Create` gombot.
* Elvárt kimenet: `Maximum stock` mezőnél megjelenik az alábbi üzenet: `The Maximum stock field is required.` 


---

### 2.2. Alapanyag szerkesztése tesztesetei
### 2.2.1. TC-01
* TP: TP-02
* Leírás: Alapanyag maximum mennyiség értékének módosítása (sikeres eset)
* Bemenet:  `Name`=`Egg`, `Stock`=`40`,   `Maximum stock` = `150`  
* Művelet: A `Maxstock` mezőt állítsuk át 200-ra.  Nyomjuk meg a `Save` gombot.
* Elvárt kimenet: A alapanyaglistában a régi maximum mennyiség helyett a `200` érték jelenik meg.


### 2.2.2. TC-02
* TP: TP-02
* Leírás: Alapanyag nevének módosítása, úgy, hogy kitöröljük az eredeti nevet és üresen hagyjuk (rossz eset)
* Bemenet: `Name`=`Sugar`, `Stock`=`50`,  `Maximum stock` = `200`
* Művelet: Töröljük ki az alapanyag nevét, és hagyjuk üresen. Nyomjuk meg a `Save` gombot.
* Elvárt kimenet: Hibaüzenet a `Name` mező alatt: `The Name field is required.`


### 2.2.3. TC-03
* TP: TP-02
* Leírás: Alapanyag készlet mennyiség értéket állítsuk át negatív értékre (rossz eset)
* Bemenet: `Name`=`Milk`, `Stock`=`150`,  `Maximum stock` = `300`
* Művelet: A `Stock` mezőt állítsuk át -1-re. Nyomjuk meg a `Save` gombot.
* Elvárt kimenet: Hibaüzenet a `Stock` mező alatt: `Please enter a value greater than or equal to 0.`



### 2.2.4. TC-04
* TP: TP-02
* Leírás: Alapanyag maximum készlet mennyiség értéket állítsuk át negatív értékre (rossz eset)
* Bemenet: `Name`=`Egg`, `Stock`=`123`,  `Maximum stock` = `210`
* Művelet: A `Maxstock` mezőt állítsuk át -1-re. Nyomjuk meg a `Save` gombot.
* Elvárt kimenet: Hibaüzenet a `Maxstock` mező alatt: `Please enter a value greater than or equal to 0.`


### 2.2.5. TC-05
* TP: TP-02
* Leírás: Alapanyag készlet mennyiség értéket állítsuk át nagyobb értékre mint a maximális készlet mennyiség értéket (rossz eset)
* Bemenet: `Name`=`Egg`, `Stock`=`123`,  `Maximum stock` = `150`
* Művelet: A `Stock` mezőt állítsuk át 170-re. Nyomjuk meg a `Save` gombot.
* Elvárt kimenet: Hibaüzenet a `Stock` mező alatt: `Please enter a value less than or equal to 150.`



### 2.3. Alapanyag törlése tesztesetei
### 2.3.1. TC-01
• TP: TP-03
• Leírás: Alapanyag törlésének tesztelése (sikeres eset)
• Bemenet: Kijelölt alapanyag: `Egg (pcs)`
• Művelet: Nyomjuk meg a `Kuka gombot` gombot. Ezután megjelenik az alábbi üzenet: `Are you sure you want to delete this ingredient? This action cannot be undone!`. Megnyomjuk a `Delete` gombot.
• Elvárt kimenet: A alapanyaglistában a `Milk (dl)` alapanyag már nem látható.
