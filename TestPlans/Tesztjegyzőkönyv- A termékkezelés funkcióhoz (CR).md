### 8.3.14. Tesztelési dokumentum a termékkezelés funkciókhoz

---

Az alábbi tesztdokumentum a `2024_IB153l-13_D` projekthez tartozó `8.3.4.1 Termékek kezelése (CR)` funkcióhoz készült. Felelőse: `Stefán Kornél`


### 1. Teszteljárások (TP)

---

### 1.1. Termék hozzáadása funkció tesztelése

---

• Azonosító: TP-01
• Tesztesetek: TC-01
• Leírás: Termék hozzáadása funkció tesztelése
       0. lépés: Nyissuk meg az alkalmazást, lépjünk be egy admin felhasználóval és menjünk a Products oldalra, és nyomjuk meg az `Add new product` gombot.
       1. lépés: Az `Name` mezőbe írjuk be a termék nevét.
       2. lépés: Az `Description` mezőbe írjuk be az jellemzőjét.
       3. lépés: Az `Price` mezőbe írjuk be a termék árát.
       4. lépés: Nyomjuk meg a `Create` gombot. 
       5. lépés: Ellenőrizzük az eredményt. Elvárt eredmény: a termék hozzáadása sikeres, és megjelenik az termék listában.



### 2. Tesztesetek (TC)

---

### 2.1. Termék hozzáadása tesztesetei

---

###2.1.1. TC-01

• TP: TP-01
• Leírás: Termék hozzáadása tesztelése (sikeres eset)
• Bemenet: Name = `croissant`, Description = `honhonhon`, Price = 650, ImageUrl = `croissant-cocoa`
• Művelet: Nyomjuk meg a `Create` gombot.
• Elvárt kimenet: A terméklistában megjelenik egy új termék: `croissant, honhonhon, 650, croissant-cocoa`.

