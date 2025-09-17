# README – Git & GitHub ve Visual Studio 2022 (Community)

> Krátký slovníček, klikací postupy (VS 2022 + GitHub web) a úplný základ OOP s ukázkami v C# (.NET 9).

---

## 1) Rychlý slovníček pojmů (co to je a k čemu to je)

- **Commit** – *uložení změn do **místního** repozitáře*. Vznikne záchytný bod s popisem změn (message).  
  **Proč:** udržuje historii, umožní návrat zpět a sdílení změn (po Push).

- **Push** – *odeslání tvých commitů na **GitHub***.  
  **Proč:** až Push zpřístupní tvoje změny ostatním.

- **Fetch** – *zjištění, co je nového na GitHubu* (nové commity) **bez** změny tvých souborů.  
  **Proč:** bezpečná kontrola, jestli mezitím někdo něco neposlal.

- **Pull** – *stáhne a **aplikuje** nové změny z GitHubu do tvého projektu*. (= Fetch + Merge)  
  **Proč:** dostaneš se na aktuální stav týmu.

- **Branch** (větev) – *oddělená linie vývoje*. Máš nezávislé commity mimo `main`.  
  **Proč:** bezpečně zkoušíš úpravy, aniž bys rozbil hlavní větev.

- **Merge** – *sloučení jedné větve do druhé* (např. `feature/ui` → `main`).  
  **Proč:** zapracuješ hotovou práci z vedlejší větve do hlavní.

- *(Doplňkově)* **Pull Request (PR)** – návrh na sloučení větve na GitHubu s možností kontroly a komentářů.  
  **Proč:** týmová kontrola před Merge.

---

## 2) Pravidla pro psaní commit message (proč je to důležité)
Dobrá zpráva u commitu šetří čas celé skupině – z historie musí být **jasné co a proč**.

**Doporučení:**
- Řádek 1: **stručný titulek do ~50 znaků**, v **rozkazovacím způsobu** (např. „Přidej třídu Vehicle“).  
- Prázdný řádek.
- Tělo: *co se změnilo a proč*, případně dopady / odkazy (např. „Fixes #12“).  
- Nepiš „update“, „oprava“ – buď konkrétní.
- Komituj **malé logické celky** (častěji a menší balíčky).

**Příklady:**
```
Špatně:  Update
Dobře:   Přidej třídu Bicycle a přepiš Start() pro šlapání
```
```
Špatně:  Oprava věcí
Dobře:   Oprav diakritiku ve výpise Student.Popis()
```

---

## 3) Jak to dělat ve **Visual Studio 2022** (klikací postupy)

### 3.1 Commit a Push (poslání tvých změn na GitHub)
1. Ulož změny v kódu (**Ctrl+S**).  
2. Otevři **View → Git Changes** (nebo panel „Git Changes“).  
3. Do **Message** napiš popis commitu.  
4. Klikni **Commit All** *(uloží lokálně)* nebo **Commit All and Push** *(uloží a hned odešle na GitHub)*.  
5. Pokud jsi dal jen Commit All, dokonči odeslání klikem na **Push** (v tomtéž panelu nebo **Git → Push**).

> Pozn.: První odeslání nové větve bývá **Publish Branch** – VS ji vytvoří i na GitHubu.

---

### 3.2 Fetch a Pull (načtení cizích změn)
- **Fetch:** **Git → Fetch** (nebo tlačítko *Fetch* v „Git Changes“). Jen zkontroluje, co je nového.  
- **Pull:** **Git → Pull** (nebo *Pull origin/main*). Stáhne a **zapracuje** změny do tvých souborů.

> Máš-li **lokální necommitnuté změny**, nejdřív je **Commit/Stash**, teprve pak Pull – předejdeš konfliktům.

---

### 3.3 Branch (větev) – vytvoření, přepnutí, smazání
1. **Vytvoření:** **Git → New Branch…**  
   - Název např. `feature/vehicle-demo`, **Base branch** `main`, **Create**.  
2. **Přepnutí:** v **Git → Manage Branches…** dvojklik na větev, nebo stavová lišta dole.  
3. Udělej změny → **Commit** → **Push/Publish Branch**.  
4. **Smazání lokální větve:** **Git → Manage Branches…** → pravým na větev → **Delete** (po merge).

---

### 3.4 Merge (sloučení větve) přímo ve VS
1. Ujisti se, že jsi na cílové větvi (typicky `main`).  
2. **Git → Manage Branches…** → pravým na `main` → **Merge From…**.  
3. Vyber zdrojovou větev (např. `feature/vehicle-demo`) → **Merge**.  
4. Pokud vzniknou **conflicty**, VS ti je ukáže v „Merge Editoru“ – vyber správné části a ulož.  
5. **Commit** výsledku sloučení (pokud VS neudělá automaticky) → **Push** na GitHub.

---

## 4) Jak to dělat na **GitHubu (web)**

### 4.1 Odeslání práce z VS na GitHub
- Po **Commit** klikni v VS na **Push/Publish Branch**. GitHubu se vytvoří/aktualizuje větev.

### 4.2 Pull Request (doporučený způsob merge v týmu)
1. Na GitHubu otevři svůj repozitář → **Compare & pull request** (po push větve).  
2. Zkontroluj rozdíly, napiš popis „co a proč“.  
3. **Create pull request** → počkej na review / schválení.  
4. **Merge pull request** → **Confirm merge**.  
5. (Volitelné) **Delete branch** na GitHubu.  
6. Vrať se do VS a udělej **Pull**, aby se ti změny promítly lokálně do `main`.

---

## 5) Časté situace a tipy
- **Chci jen zjistit, jestli je něco nového** → **Fetch**.  
- **Chci stáhnout a použít nové změny** → **Pull**.  
- **Chci poslat svou práci** → **Commit → Push**.  
- **Nepracuju přímo v `main`** → vytvoř **branch**, pracuj tam, a pak **Merge / PR**.  
- **.gitignore** – drž mimo Git složky `bin/`, `obj/`, uživatelské `.vs/` apod. (VS šablona to umí nastavit).

---

## 6) OOP – co to je a jednoduché ukázky v C# (.NET 9)

**OOP (Object-Oriented Programming)** = způsob psaní programů pomocí **objektů**, které mají **stav** (data) a **chování** (metody).  
Základní principy: **zapouzdření**, **dědičnost**, **polymorfismus** a **abstrakce**.

### 6.1 Zapouzdření (encapsulation)
Skrytí interních dat za veřejným rozhraním.
```csharp
public class Student
{
    private int _vek;                 // skrytý stav
    public string Jmeno { get; set; } // veřejná vlastnost

    public int Vek                   // kontrolovaný přístup k _vek
    {
        get { return _vek; }
        set { _vek = value < 0 ? 0 : value; }
    }

    public string Popis()
    {
        return "Student: " + Jmeno + ", věk: " + Vek;
    }
}
```

### 6.2 Dědičnost (inheritance) a 6.3 Polymorfismus (polymorphism)
Potomek přebírá vlastnosti a metody rodiče a může je **přepsat** (override).
```csharp
public class Vehicle
{
    public virtual string Kind
    {
        get { return "Vozidlo"; }
    }

    public virtual string Start()
    {
        return Kind + " startuje.";
    }
}

public class Car : Vehicle
{
    public override string Kind
    {
        get { return "Auto"; }
    }

    public override string Start()
    {
        return Kind + " nastartovalo motor.";
    }
}

public class Bicycle : Vehicle
{
    public override string Kind
    {
        get { return "Kolo"; }
    }

    public override string Start()
    {
        return Kind + " se rozjíždí šlápnutím do pedálů.";
    }
}
```
Použití (polymorfismus – společné rozhraní, různé chování):
```csharp
List<Vehicle> garage = new List<Vehicle>();
garage.Add(new Car());
garage.Add(new Bicycle());

foreach (Vehicle v in garage)
{
    Console.WriteLine(v.Start()); // volá správnou přepsanou verzi
}
```

### 6.4 Abstrakce (abstraction)
Zdůraznění „co“ má objekt umět, ne „jak“ to uvnitř dělá.
```csharp
public abstract class Shape
{
    public abstract double GetArea();
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public override double GetArea()
    {
        return Width * Height;
    }
}
```

---

## 7) Rychlý tahák (1 slide)
- **Commit** – ulož změny lokálně (dobrý popis!).  
- **Push** – pošli commity na GitHub.  
- **Fetch** – jen zjisti, co je nového.  
- **Pull** – stáhni a zapracuj změny.  
- **Branch** – pracuj mimo `main`.  
- **Merge** – slouč větev do `main` (ideálně přes **Pull Request**).

---

*Autor: učební materiál k předmětu – práce s Git/GitHub ve VS 2022, C# .NET 9.*
