### Összefoglaló az 2. mérföldkőben végzett munkáról

### Projekt tag: `Stefán Kornél`

___

#### Vállalásaim a mérföldkőben: 

 - 8.2.1. Use Case diagram

    ##### A feladathoz tartozó issue(k):

     - [#9](https://git-okt.sed.inf.szte.hu/2024_ib153l-13_d/2024_ib153l-13_d/-/issues/9)

    ##### A feladat elvégzését alátámasztó commit(ok):

     - [496c1c34a9ec133c17803ec4d6b336abef1133aa](https://git-okt.sed.inf.szte.hu/2024_ib153l-13_d/2024_ib153l-13_d/-/commit/496c1c34a9ec133c17803ec4d6b336abef1133aa)
     
#### Megjegyzések

A második mérföldkőnél, miután megküzdöttünk a tervezési szakasz sűrű erdejével, diadalmasan továbbléptünk, hogy elkészítsük azokat a dokumentumokat, amiket minden fejlesztési projekt látszólag elvár, még ha senki sem tudja pontosan, mire jók. Így született meg a Use Case diagram, a fejlesztők és designerek közös álma (vagy rémálma), amely részletesen megmutatja, mit is fog csinálni a szoftver – legalábbis elméletben. Ez a diagram egyébként azért is hasznos, mert ha egyszer végre kódolni kezdünk, emlékezni fogunk, mit is akartunk eredetileg.

Ezután a Class diagram következett, ahol megpróbáltuk megteremteni a szoftver felépítésének gerincét. Itt hirtelen mindenki Java osztályokra kezdett gondolni, még azok is, akik utálják a kávét. Lassan, de biztosan sikerült megterveznünk az osztályokat, amelyek talán egyszer majd tényleg hasznosak lesznek, ha összekötjük őket a valósággal.

A harmadik fázisban jött a Sequence diagram, ahol az események sorrendjét kellett megtervezni. Ez a diagram sokat elárul arról, hogy mi történik, ha a felhasználó kattint egy gombra. Vagy ha véletlenül másra kattint, mint kéne. Ebből a diagramból kiderül, hogy ki mit csinál, mikor és hogyan – mert valahol rendnek kell lennie, még akkor is, ha a káosz látszik kívülről.

Nem maradhatott ki a Package diagram sem, amelyre a fejlesztők már régóta vártak, hiszen végre össze lehetett kötni a különböző modulokat, hogy ne érezzük azt, hogy csak a vakvilágba dobáljuk az osztályainkat. Ezzel végre összhangba került a szoftver logikai felépítése – legalábbis addig, amíg valaki ki nem találja, hogy mégis újrafelébezzük az egészet.

Az Egyed-kapcsolat diagram volt az, ahol minden adatbázisért rajongó szíve megdobbant. Képeztünk egy halom entitást, amik csodás kapcsolatba léptek egymással – persze csak elméletben, hiszen a valóságban ezek az entitások inkább veszekedni szoktak, mintsem barátságot kötni. Az adatmodellek révén sikerült leírnunk, hogy mely táblák fognak majd szép kerek rekordokat tárolni. Az persze más kérdés, hogy ezek hogyan fognak működni a gyakorlatban, de erről később fogunk beszámolni.

És végül, de nem utolsósorban, a csapat hősies megpróbáltatásai során megszülettek a felülettervek is. Ezek a tervek megmutatták, hogyan fog kinézni az alkalmazás, amikor a felhasználók először ránéznek – és valószínűleg gyorsan becsukják majd, ha nem tetszik nekik. De most még optimisták vagyunk, hiszen a tervek szépek és csillogóak, színes gombokkal, finom vonalakkal, és egy olyan navigációs menüvel, amit még senki sem talált túl bonyolultnak. Persze, ez még csak az első változat, úgyhogy az igazi kihívások még előttünk állnak.