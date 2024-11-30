## 8.3.12. Tesztelési dokumentum a felhasználókezeléshez (tesztjegyzőkönyv)

---

Az alábbi tesztdokumentum a `2024_IB153l-13_D` projekthez tartozó `8.3.1. Adminisztratív felhasználók kezelése (kolléga, ügyfél) (CRUD)` funkcióhoz készült. Felelőse: `Farkas Dominika Eliza`

### 1. Teszteljárások (TP)

---

#### 1.1. Felhasználók (Users) oldal tesztelése

---

* Azonosító: TP-01
* Tesztesetek: TC-01, TC-02, TC-03, TC-04, TC-05
* Leírás: Felhasználók adatai és jogosultságaik megtekintése, módosítása, törlése és új felhasználó létrehozása.
 * Indítsuk el az alkalmazást, és jelentkezzünk be adminisztrátor felhasználóval.
 * Menjünk az `Users` oldalra, és az összes felhasználó megjelenik az adataikkal.
 * Az `Users` oldalon válasszunk ki egy felhasználót, és a `Details` gombbal megtekinthetjük az adatait.
 * Az `Users` oldalon válasszunk ki egy felhasználót, és az `Edit` gombbal módosítsuk a felhasználói jogosultságokat vagy adatait az input mezőkben (email, jelszó).
 * Nyomjuk meg a `Save` gombot.
 * Az `Users` oldalon nyomjuk meg a `Add user` gombot, majd az inputmezőkbe beírjuk az adatokat és kiválasztjuk a legördülő menüből a megfelelő jogosultságot.
 * Nyomjuk meg a `Create` gombot.
 * Az `Users` oldalon válasszunk ki egy felhasználót, majd nyomjuk meg mellette a `Delete` gombot, majd a felugró ablakban a `Delete` gombot.
 * Ellenőrizzük az eredményt. Elvárt eredmény:
   * A jogosultságok helyesen frissülnek a felhasználói adatbázisban.
   * Hibás beállítások esetén megfelelő hibaüzenet jelenik meg.

### 2. Tesztesetek (TC)

---

#### 2.1. Felhasználók (Users) oldal tesztesetei

---

#### 2.1.1. TC-01

* TP: TP-01
* Leírás: Felhasználói jogosultságok módosítása.
* Bemenet: email, new_role
* Művelet: Az `Users` oldalon válasszuk ki a felhasználót, és az `Edit` gombbal módosítsuk a jogosultságokat a legördülő inputmező segítségével.
* Elvárt kimenet:
 * A jogosultságok sikeresen frissülnek a felhasználói adatbázisban.

#### 2.1.2. TC-02

* TP: TP-01
* Leírás: Felhasználó adatok módosítása.
* Bemenet: new_email, new_password, role
* Művelet: Az `Users` oldalon válasszuk ki a felhasználót, és az `Edit` gombbal módosítsuk az adatokat az inputmezők segítségével.
* Elvárt kimenet:
 * Az email és a jelszó is sikeresen frissülnek a felhasználói adatbázisban.

#### 2.1.3. TC-03

* TP: TP-01
* Leírás: Új felhasználó létrehozása.
* Bemenet: email, password, role
* Művelet: Az `Users` oldalon nyomjuk meg a `Create new user` gombot, majd kitöltjük az inputmezőket az adatokkal és kiválasztjuk a szerepkörét a legördülő menüből.
* Elvárt kimenet:
 * Az új felhasználók sikeresen megjelennek a felhasználói adatbázisban.

#### 2.1.4. TC-04

* TP: TP-01
* Leírás: Felhasználók adatai megtekintése.
* Bemenet: -
* Művelet: Az `Users` oldalon nyomjuk meg a `Details` gombot, majd megjelenik az adott felhasználó összes adata.
* Elvárt kimenet:
 * Az új felhasználók sikeresen megjelennek az oldalon.

#### 2.1.5. TC-05

* TP: TP-01
* Leírás: Felhasználó törlése.
* Bemenet: -
* Művelet: Az `Users` oldalon válasszuk ki a felhasználót, majd nyomjuk meg a `Delete` gombot, majd a felugró ablakban a `Delete` gombot.
* Elvárt kimenet:
 * A felhasználó sikeresen törlődik a felhasználói adatbázisból.

### 3. Tesztriportok (TR)

---

#### 3.1. Felhasználók (Users) oldal tesztriportjai

---

#### 3.1.1. TR-01 (TC-01)

* TP: TP-01
  * Az `Users` oldalon kiválasztottam egy felhasználót.
  * Az `Edit` gombot megnyomtam, és módosítottam a jogosultságokat a legördülő inputmező segítségével.
  * A `Save` gombot megnyomtam.
  * A jogosultságok sikeresen frissültek a felhasználói adatbázisban és a weboldalon is az új adat látható.
  * Helyes eredményt kaptam.

#### 3.1.2. TR-02 (TC-02)

* TP: TP-01
  * Az `Users` oldalon kiválasztottam egy felhasználót.
  * Az `Edit` gombot megnyomtam, és módosítottam az email és jelszó adatokat az inputmezők segítségével.
  * A `Save` gombot megnyomtam.
  * Az email és a jelszó sikeresen frissültek a felhasználói adatbázisban.
  * Helyes eredményt kaptam.

#### 3.1.3. TR-03 (TC-03)

* TP: TP-01
  * Az `Users` oldalon a `Add user` gombot megnyomtam.
  * Kitöltöttem az inputmezőket az adatokkal és kiválasztottam a szerepkört a legördülő menüből.
  * A `Save` gombot megnyomtam.
  * Az új felhasználók sikeresen megjelentek a felhasználói adatbázisban.
  * Helyes eredményt kaptam.

#### 3.1.4. TR-04 (TC-04)

* TP: TP-01
  * Az `Users` oldalon a `Details` gombot megnyomtam.
  * Az adott felhasználó összes adata megjelent.
  * Helyes eredményt kaptam.

#### 3.1.5. TR-05 (TC-05)

* TP: TP-01
  * Az `Users` oldalon kiválasztottam egy felhasználót.
  * A `Delete` gombot megnyomtam, majd a felugró ablakban a `Delete` gombot.
  * A felhasználó sikeresen törlődött a felhasználói adatbázisból.
  * Helyes eredményt kaptam.
