## 8.3.12. Tesztelési dokumentum a felhasználókezeléshez (tesztjegyzőkönyv)

---

Az alábbi tesztdokumentum a `2024_IB153l-13_D` projekthez tartozó `8.3.1. Adminisztratív felhasználók kezelése (kolléga, ügyfél) (CRUD)` funkcióhoz készült. Felelőse: `Farkas Dominika Eliza`

### 1. Teszteljárások (TP)

---

#### 1.1. Bejelentkezés tesztelése

---

* Azonosító: TP-01
* Tesztesetek: TC-01, TC-02, TC-03
* Leírás: Bejelentkezési folyamat tesztelése.
 * Indítsuk el az alkalmazást, és menjünk a `Login` oldalra.
 * Adjuk meg a felhasználónevet és jelszót, majd nyomjuk meg a `Login` gombot.
 * Hibás adatok esetén ellenőrizzük a hibaüzenetet.
 * Ellenőrizzük az eredményt. Elvárt eredmény:
   * Helyes felhasználónév és jelszó esetén a felhasználó belép az alkalmazásba.
   * Hibás adatok esetén megfelelő hibaüzenet jelenik meg.

#### 1.2. Regisztráció tesztelése

---

* Azonosító: TP-02
* Tesztesetek: TC-04, TC-05, TC-06
* Leírás: Regisztrációs folyamat tesztelése.
  * Indítsuk el az alkalmazást, és menjünk a `Login` oldalra és ott kattintsunk a `Create new account` gombra.
  * Töltsük ki a regisztrációs űrlapot a szükséges adatokkal (email, jelszó, jelszó mégegyszer).
  * Nyomjuk meg a `Register` gombot.
  * Ellenőrizzük az eredményt. Elvárt eredmény:
    * Helyes adatok esetén a felhasználó regisztrálva lesz és megjelenik az oldal jobb alsó sarkában egy üzenet a sikeres regisztrációról.
    * Hibás adatok esetén megfelelő hibaüzenet jelenik meg az oldal jobb alsó sarkában.

#### 1.3. Felhasználók (Users) oldal tesztelése

---

* Azonosító: TP-03
* Tesztesetek: TC-07, TC-08, TC-09, TC-10
* Leírás: Felhasználók adatai és jogosultságaik megtekintése, módosítása, törlése és új felhasználó létrehozása.
 * Indítsuk el az alkalmazást, és jelentkezzünk be adminisztrátor felhasználóval.
 * Menjünk az `Users` oldalra, és az összes felhasználó megjelenik az adataikkal.
 * Az `Users` oldalon válasszunk ki egy felhasználót, és a `Details` gombbal megtekinthetjük az adatait.
 * Az `Users` oldalon válasszunk ki egy felhasználót, és az `Edit` gombbal módosítsuk a felhasználói jogosultságokat vagy adatait az input mezőkben (email, jelszó).
 * Nyomjuk meg a `Save` gombot.
 * Az `Users` oldalon nyomjuk meg a `Create new user` gombot, majd az inputmezőkbe beírjuk az adatokat és kiválasztjuk a legördülő menüből a megfelelő jogosultságot.
 * Nyomjuk meg a `Create` gombot.
 * Ellenőrizzük az eredményt. Elvárt eredmény:
   * A jogosultságok helyesen frissülnek a felhasználói adatbázisban.
   * Hibás beállítások esetén megfelelő hibaüzenet jelenik meg.

### 2. Tesztesetek (TC)

---

#### 2.1. Bejelentkezés tesztesetei

---

#### 2.1.1. TC-01

* TP: TP-01
* Leírás: Helyes felhasználónév és jelszó tesztelése.
* Bemenet: admin@bellacroissant.fr, correctpassword
* Művelet: Nyomjuk meg a `Login` gombot.
* Elvárt kimenet:
  * "You logged in successfully!" felirat megjelenik a képernyő jobb alsó sarkában zölden.

#### 2.1.2. TC-02

* TP: TP-01
* Leírás: Hibás felhasználónév tesztelése.
* Bemenet: wrong_username, password
* Művelet: Nyomjuk meg a `Login` gombot.
* Elvárt kimenet:
 * Hibaüzenet jelenik meg a képernyő jobb alsó sarkában pirosan: "User does not exist with that E-mail address!"

#### 2.1.3. TC-03

* TP: TP-01
* Leírás: Hibás jelszó tesztelése.
* Bemenet: admin@bellacroissant.fr, wrong_password
* Művelet: Nyomjuk meg a `Login` gombot.
* Elvárt kimenet:
 * Hibaüzenet jelenik meg a képernyő jobb alsó sarkában pirosan: "Invalid password!"

#### 2.2. Regisztráció tesztesetei

---

#### 2.2.1. TC-04

* TP: TP-02
* Leírás: Helyes regisztrációs adatok tesztelése.
* Bemenet: email, password, password_again
* Művelet: Nyomjuk meg a `Register` gombot.
* Elvárt kimenet:
 * A felhasználó sikeresen regisztrálva lesz, és megjelenik az oldal jobb alsó sarkában egy üzenet a sikeres regisztrációról: "You registered succesfully! Please log in now...".

#### 2.2.2. TC-05

* TP: TP-02
* Leírás: Regisztráció adatbázisban létező email címmel tesztelése.
* Bemenet: existing_email, password, password_again
* Művelet: Nyomjuk meg a `Register` gombot.
* Elvárt kimenet:
 * Hibaüzenet jelenik meg az oldal jobb alsó sarkában: "User already exists with that E-mail address!"

#### 2.2.3. TC-06

* TP: TP-02
* Leírás: Két jelszó nem egyezik tesztelése.
* Bemenet: email, password, another_password_again
* Művelet: Nyomjuk meg a `Register` gombot.
* Elvárt kimenet:
 * Hibaüzenet jelenik meg az oldal jobb alsó sarkában: "The two passwords must match!"

#### 2.3. Felhasználók (Users) oldal tesztesetei

---

#### 2.3.1. TC-07

* TP: TP-03
* Leírás: Felhasználói jogosultságok módosítása.
* Bemenet: email, new_role
* Művelet: Az `Users` oldalon válasszuk ki a felhasználót, és az `Edit` gombbal módosítsuk a jogosultságokat a legördülő inputmező segítségével.
* Elvárt kimenet:
 * A jogosultságok sikeresen frissülnek a felhasználói adatbázisban.

#### 2.3.2. TC-08

* TP: TP-03
* Leírás: Felhasználó adatok módosítása.
* Bemenet: new_email, new_password, role
* Művelet: Az `Users` oldalon válasszuk ki a felhasználót, és az `Edit` gombbal módosítsuk az adatokat az inputmezők segítségével.
* Elvárt kimenet:
 * Az email és a jelszó is sikeresen frissülnek a felhasználói adatbázisban.

#### 2.3.3. TC-09

* TP: TP-03
* Leírás: Új felhasználó létrehozása.
* Bemenet: email, password, role
* Művelet: Az `Users` oldalon nyomjuk meg a `Create new user` gombot, majd kitöltjük az inputmezőket az adatokkal és kiválasztjuk a szerepkörét a legördülő menüből.
* Elvárt kimenet:
 * Az új felhasználók sikeresen megjelennek a felhasználói adatbázisban.

#### 2.3.4. TC-10

* TP: TP-03
* Leírás: Felhasználók adatai megtekintése.
* Bemenet: -
* Művelet: Az `Users` oldalon nyomjuk meg a `Details` gombot, majd megjelenik az adott felhasználó összes adata.
* Elvárt kimenet:
 * Az új felhasználók sikeresen megjelennek az oldalon.

### 3. Tesztriportok (TR)

---

#### 3.1. Bejelentkezés tesztriportjai

#### 3.1.1. TR-01 (TC-01)

* TP: TP-01
* Megadtam egy létező felhasználónevet: admin@bellacroissant.fr, és a hozzátartozó jelszót: correctpassword.
* A `Login` gombot megnyomtam.
* A "You logged in successfully!" felirat megjelent a képernyő jobb alsó sarkában zölden.
* Helyes eredményt kaptam.

#### 3.1.2. TR-02 (TC-02)

* TP: TP-01
* Megadtam egy hibás felhasználónevet: wrong_username.
* A `Login` gombot megnyomtam.
* Hibaüzenet jelent meg a képernyő jobb alsó sarkában pirosan: "User does not exist with that E-mail address!"
* Helyes eredményt kaptam.

#### 3.1.3. TR-03 (TC-03)

* TP: TP-01
* Megadtam egy létező felhasználónevet: admin@bellacroissant.fr, és egy hibás jelszót: wrong_password.
* A `Login` gombot megnyomtam.
* Hibaüzenet jelent meg a képernyő jobb alsó sarkában pirosan: "Invalid password!"
* Helyes eredményt kaptam.

#### 3.2. Regisztráció tesztriportjai

---

#### 3.2.1. TR-04 (TC-04)

* TP: TP-02
* Megadtam egy email címet és jelszót: email, password.
* A `Register` gombot megnyomtam.
* Sikeresen regisztráltam a felhasználót, és megjelent az oldal jobb alsó sarkában egy üzenet a sikeres regisztrációról: "You registered succesfully! Please log in now...".
* Helyes eredményt kaptam.

#### 3.2.2. TR-05 (TC-05)

* TP: TP-02
* Megadtam egy adatbázisban létező email címet: existing_email.
* A `Register` gombot megnyomtam.
* Hibaüzenet jelent meg az oldal jobb alsó sarkában: "User already exists with that E-mail address!".
* Helyes eredményt kaptam.

#### 3.2.3. TR-06 (TC-06)

* TP: TP-02
* Megadtam két különböző jelszót: password és another_password_again.
* A `Register` gombot megnyomtam.
* Hibaüzenet jelent meg az oldal jobb alsó sarkában: "The two passwords must match!".
* Helyes eredményt kaptam.

#### 3.3. Felhasználók (Users) oldal tesztriportjai

---

#### 3.3.1. TR-07 (TC-07)

* TP: TP-03
  * Az `Users` oldalon kiválasztottam egy felhasználót.
  * Az `Edit` gombot megnyomtam, és módosítottam a jogosultságokat a legördülő inputmező segítségével.
  * A `Save` gombot megnyomtam.
  * A jogosultságok sikeresen frissültek a felhasználói adatbázisban és a weboldalon is az új adat látható.
  * Helyes eredményt kaptam.

#### 3.3.2. TR-08 (TC-08)

* TP: TP-03
  * Az `Users` oldalon kiválasztottam egy felhasználót.
  * Az `Edit` gombot megnyomtam, és módosítottam az email és jelszó adatokat az inputmezők segítségével.
  * A `Save` gombot megnyomtam.
  * Az email és a jelszó sikeresen frissültek a felhasználói adatbázisban.
  * Helyes eredményt kaptam.

#### 3.3.3. TR-09 (TC-09)

* TP: TP-03
  * Az `Users` oldalon a `Create new user` gombot megnyomtam.
  * Kitöltöttem az inputmezőket az adatokkal és kiválasztottam a szerepkört a legördülő menüből.
  * A `Save` gombot megnyomtam.
  * Az új felhasználók sikeresen megjelentek a felhasználói adatbázisban.
  * Helyes eredményt kaptam.

#### 3.3.4. TR-10 (TC-10)

* TP: TP-03
  * Az `Users` oldalon a `Details` gombot megnyomtam.
  * Az adott felhasználó összes adata megjelent.
  * Helyes eredményt kaptam.
