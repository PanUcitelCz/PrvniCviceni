
# Základy C# a Git — rychlý průvodce (README)

> Krátký, praktický úvod do jazyka **C#**, principů **OOP** (zapouzdření, dědičnost, polymorfismus, abstrakce) a do práce se **Gitem** (commit, push, pull, branch atd.), včetně doporučených pravidel.

---

## Obsah
- [Jak číst a používat tento dokument](#jak-číst-a-používat-tento-dokument)
- [1) Základy C#](#1-základy-c)
  - [Hello, World](#hello-world)
  - [Proměnné a typy](#proměnné-a-typy)
  - [Podmínky a cykly](#podmínky-a-cykly)
  - [Metody a parametry](#metody-a-parametry)
  - [Třídy, struktury, rozhraní, záznamy](#třídy-struktury-rozhraní-záznamy)
  - [Výjimky](#výjimky)
  - [Kolekce a LINQ](#kolekce-a-linq)
  - [Asynchronní programování (async/await)](#asynchronní-programování-asyncawait)
- [2) OOP v kostce](#2-oop-v-kostce)
  - [Zapouzdření (Encapsulation)](#zapouzdření-encapsulation)
  - [Dědičnost (Inheritance)](#dědičnost-inheritance)
  - [Polymorfismus (Polymorphism)](#polymorfismus-polymorphism)
  - [Abstrakce (Abstraction)](#abstrakce-abstraction)
  - [Kompozice vs. dědičnost](#kompozice-vs-dědičnost)
  - [SOLID v jedné minutě](#solid-v-jedné-minutě)
- [3) Git — základy a pravidla](#3-git--základy-a-pravidla)
  - [Co je Git a důležité pojmy](#co-je-git-a-důležité-pojmy)
  - [Základní příkazy](#základní-příkazy)
  - [Pull, Fetch, Merge, Rebase — rozdíly](#pull-fetch-merge-rebase--rozdíly)
  - [Doporučená pravidla pro práci s Gitem](#doporučená-pravidla-pro-práci-s-gitem)
  - [Ukázkový workflow (GitHub Flow)](#ukázkový-workflow-github-flow)
  - [.gitignore pro .NET/C#](#gitignore-pro-netc)
  - [Užitečné aliasy do `.gitconfig`](#užitečné-aliasy-do-gitconfig)
- [4) Mini‑úkoly k procvičení](#4-miniúkoly-k-procvičení)

---

## Jak číst a používat tento dokument
- V kapitolách **C#** najdeš krátké vysvětlení a **běžné ukázky kódu**.
- V kapitolách **Git** je vše, co potřebuješ k běžné práci s repozitářem a GitHubem, **včetně pravidel**.
- Kopíruj kód do vlastního projektu (doporučené .NET 8.0). Pro rychlý start můžeš vytvořit novou konzolovou app:
  ```bash
  dotnet new console -n DemoApp
  cd DemoApp
  dotnet run
  ```

---

## 1) Základy C#

### Hello, World
Moderní C# podporuje **top‑level statements** (bez třídy `Program`):
```csharp
using System;

Console.WriteLine("Ahoj světe!");
```
Klasický styl:
```csharp
using System;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ahoj světe!");
        }
    }
}
```

### Proměnné a typy
```csharp
int i = 42;
double d = 3.14;
bool ok = true;
string s = "text";
var auto = 123;      // typ odvozen z pravé strany (zde int)

// Interpolace řetězce
Console.WriteLine($"i={i}, d={d:F2}, ok={ok}, s={s}");

// Konverze
int parsed = int.Parse("123");        // vyhodí výjimku při neúspěchu
if (int.TryParse("123", out int n))   // bezpečnější
{
    Console.WriteLine(n);
}
```

### Podmínky a cykly
```csharp
int x = 10;

if (x > 5)
    Console.WriteLine("větší než 5");
else if (x == 5)
    Console.WriteLine("rovno 5");
else
    Console.WriteLine("menší než 5");

switch (x)
{
    case 1:
    case 2:
        Console.WriteLine("1 nebo 2");
        break;
    default:
        Console.WriteLine("něco jiného");
        break;
}

for (int k = 0; k < 3; k++)
    Console.WriteLine(k);

int[] arr = { 1, 2, 3 };
foreach (var v in arr)
    Console.WriteLine(v);
```

### Metody a parametry
```csharp
// Výchozí hodnoty a expression-bodied members
static int Add(int a, int b = 0) => a + b;

// ref/out parametry (používat střídmě)
static void Increment(ref int value) => value++;
static bool TryDivide(int a, int b, out int result)
{
    if (b == 0) { result = 0; return false; }
    result = a / b; return true;
}
```

### Třídy, struktury, rozhraní, záznamy
```csharp
public class BankAccount
{
    private decimal _balance;           // zapouzdřený stav

    public decimal Balance              // vlastnost (property)
    {
        get => _balance;
        private set
        {
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
            _balance = value;
        }
    }

    public void Deposit(decimal amount) => Balance += amount;

    public bool TryWithdraw(decimal amount)
    {
        if (amount <= _balance) { Balance -= amount; return true; }
        return false;
    }
}

public interface IFlyable { void Fly(); }          // rozhraní

public abstract class Animal                      // abstraktní třída
{
    public string Name { get; }
    protected Animal(string name) => Name = name;
    public abstract void Speak();                 // abstraktní metoda
}

public class Dog : Animal
{
    public Dog(string name) : base(name) { }
    public override void Speak() => Console.WriteLine($"{Name}: Haf!");
}

public class Duck : Animal, IFlyable              // dědičnost + rozhraní
{
    public Duck(string name) : base(name) { }
    public override void Speak() => Console.WriteLine($"{Name}: Kvak!");
    public void Fly() => Console.WriteLine($"{Name} letí!");
}

// Záznam (record) – imutabilní nosič dat s hodnotovou rovností
public record Point(int X, int Y);
```

### Výjimky
```csharp
try
{
    var text = File.ReadAllText("data.txt");
}
catch (FileNotFoundException ex)
{
    Console.Error.WriteLine($"Soubor nenalezen: {ex.FileName}");
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Neočekávaná chyba: {ex.Message}");
}
finally
{
    Console.WriteLine("Hotovo.");
}
```

### Kolekce a LINQ
```csharp
using System.Collections.Generic;
using System.Linq;

var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
var squaresOfEvens = numbers
    .Where(n => n % 2 == 0)
    .Select(n => n * n)
    .ToList(); // {4, 16, 36}
```

### Asynchronní programování (async/await)
```csharp
using System.Net.Http;
using System.Threading.Tasks;

static async Task<string> FetchAsync(string url)
{
    using var client = new HttpClient();
    using var resp = await client.GetAsync(url);
    resp.EnsureSuccessStatusCode();
    return await resp.Content.ReadAsStringAsync();
}

// použití: var html = await FetchAsync("https://example.com");
```

---

## 2) OOP v kostce

### Zapouzdření (Encapsulation)
- **Oddělení interního stavu** od veřejného rozhraní třídy.
- Realizováno modifikátory přístupu (`private`, `public`, `protected`, `internal`) a vlastnostmi (get/set).
- Cíl: **invarianty**, čitelný a bezpečný objekt.

### Dědičnost (Inheritance)
- Umožňuje tvořit hierarchii „**is‑a**“ (např. `Dog` **je** `Animal`).
- Společné chování do předka, rozšíření v potomkovi.

### Polymorfismus (Polymorphism)
- Stejné API, **různé chování**.
- Přes klíčová slova `virtual`, `override`, případně přes **rozhraní**.
```csharp
var animals = new List<Animal> { new Dog("Rex"), new Duck("Kvak") };
foreach (var a in animals) a.Speak(); // volá správnou implementaci podle konkrétního typu
```

### Abstrakce (Abstraction)
- Vypuštění detailů, ponechání podstaty (např. abstraktní třídy a rozhraní).
- Umožňuje **nahraditelnost** a **testovatelnost**.

### Kompozice vs. dědičnost
- **Kompozice („has‑a“) často vítězí** nad dědičností: skládám objekty z menších částí.
```csharp
public class Car
{
    private readonly Engine _engine = new();
    public void Drive() => _engine.Run();
}
```

### SOLID v jedné minutě
- **S**ingle Responsibility — jedna zodpovědnost na třídu.
- **O**pen/Closed — rozšiřuj bez změny existujícího kódu.
- **L**iskov Substitution — potomek musí být zaměnitelný za předka.
- **I**nterface Segregation — rozhraní dělit na menší cílené celky.
- **D**ependency Inversion — záviset na abstrakcích, ne na implementacích.

---

## 3) Git — základy a pravidla

### Co je Git a důležité pojmy
- **Repozitář**: adresář s historii změn (složka `.git`).
- **Pracovní strom** → **Staging (index)** → **Commit (historie)**.
- **Branch** (větev), **tag**, **remote** (např. `origin`), **HEAD** (aktuální commit/branch).

### Základní příkazy
| Příkaz | Popis | Kdy použít |
|---|---|---|
| `git init` | Inicializuje nový repozitář | Začátek v prázdném adresáři |
| `git clone <url>` | Klon vzdáleného repo | Převzetí existujícího projektu |
| `git status` | Stav pracovního stromu a indexu | Před commitem, při řešení konfliktů |
| `git add <soubor>` | Přidá změny do **stagingu** | Připravíš změny k commitu |
| `git commit -m "..."` | Vytvoří commit | Zaznamenáš logickou jednotku práce |
| `git log --oneline --graph --decorate` | Přehled historie | Rychlá orientace v commitech |
| `git diff` / `git diff --staged` | Rozdíly v souboru | Před commitem / po `add` |
| `git branch` / `git switch -c <větev>` | Správa větví | Tvorba a přepínání větví |
| `git merge <větev>` | Sloučení historie | Sloučení feature do `main` |
| `git rebase <větev>` | Přepsání báze | Linearizace historie (opatrně) |
| `git fetch` | Stáhne nové commity **bez** sloučení | Synchronizace bez změny pracovního stromu |
| `git pull` | = `fetch` + sloučení (merge/rebase) | Aktualizace lokální větve ze vzdálené |
| `git push` | Odeslání commitů do remote | Sdílení práce |
| `git stash` | Dočasně odloží změny | Rychlé přepnutí kontextu |
| `git reset` / `git restore` | Vrácení změn (různé úrovně) | Opravy a úklid |
| `git tag -a v1.0 -m "verze 1.0"` | Označení commitů verzí | Release body |

### Pull, Fetch, Merge, Rebase — rozdíly
- **fetch**: stáhne novinky z remote, ale **nemění** aktuální větev.
- **pull**: `fetch` + sloučení do aktuální větve (default **merge**, lze `--rebase`).
- **merge**: vytvoří nový „merge commit“ a zachová větvenou historii.
- **rebase**: „přepíše bázi“ commitů na jiný vrchol (lineární historie). **Nikdy nerebasuj sdílenou/pushnutou větev**, pokud si nejsi jistý dopady.

### Doporučená pravidla pro práci s Gitem
1. **Malé a srozumitelné commity** (1 logická změna = 1 commit).
2. **Slušné zprávy commitů** v **imperativu** (např. „Přidej validaci vstupu“, ne „Přidal jsem…“).
3. **Branch naming**: `feature/…`, `bugfix/…`, `hotfix/…` (bez diakritiky, malá písmena, pomlčky/slashe).
4. **.gitignore** drž aktuální, necommituj `bin/`, `obj/`, build artefakty a tajemství (API klíče).
5. Před `push` na sdílené větve (např. `main`) **spusť testy** a **lint**.
6. **Pull request**: popiš účel, odkaz na issue, přidej screenshoty, **self‑review** před žádostí o review.
7. **Rebase vs. merge**: preferuj **rebase** na **lokálních feature větvích** pro čistotu; pro integraci do `main` bývá bezpečnější **merge** nebo **squash‑merge**.
8. **Ne přepisovat historii** na sdílených větvích (`git push --force` jen výjimečně a domluveně).
9. **Řešení konfliktů**: nejdřív pochop kontext, uprav, otestuj, **commit** s jasnou zprávou typu „Resolve merge conflict in …“.
10. **Taguj releasy** (např. `v1.2.0`) a piš **CHANGELOG** (aspoň hlavní změny).

### Ukázkový workflow (GitHub Flow)
```bash
# 0) Aktuální main
git switch main
git pull

# 1) Nová feature větev
git switch -c feature/login-form

# 2) Práce + malé commity
git add src/Login.cs
git commit -m "Přidej základní formulář pro přihlášení"

# 3) Průběžná synchronizace
git fetch
git rebase origin/main     # nebo git merge origin/main

# 4) Odeslání a PR
git push -u origin feature/login-form
# Na GitHubu otevři Pull Request, popiš změny, požádej o review.

# 5) Sloučení do main (merge/squash), smazání větve
```

### .gitignore pro .NET/C#
V souboru `.gitignore` (zkráceně):
```
# Build artefakty
bin/
obj/

# IDE
.vs/
.vscode/
*.user
*.suo

# OS
.DS_Store
Thumbs.db
```

### Užitečné aliasy do `.gitconfig`
```ini
[alias]
  s = status -sb
  lg = log --oneline --graph --decorate --all
  co = switch
  cob = switch -c
  ci = commit
  st = status
  df = diff
  last = log -1 HEAD
```

---

## 4) Mini‑úkoly k procvičení
- **C#**: Napiš třídu `Temperature` s vlastnostmi ve °C a °F (přepočet v setru/getru), validuj rozsah.
- **OOP**: Vytvoř `Shape` (abstraktní) a potomky `Circle`, `Rectangle` s metodou `Area()` a polymorfním výpočtem.
- **LINQ**: Z kolekce řetězců vyfiltruj ty delší než 3 znaky, setřiď abecedně a vypsat.
- **Git**: Založ větev `feature/shapes`, commitni `Shape` řešení, otevři PR a po review slouč do `main`.
