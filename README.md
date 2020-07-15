# POE Hideout Ground

Project for generating simple ground for the Celestial Nebula hideout in POE.

Url link: https://poehideoutground.com/


## Installation

Download <a href="https://dotnet.microsoft.com/download">Blazor</a>.

Open your cmdline and clone this repository. 

```
`git clone https://github.com/JonathanMcCaffrey/poe-hideoutground.git`.
```

Open and change your cmdline to the POEHideoutGround directory.

```
cd poe-hideoutground/POEHideoutGround
```

Run the Blazor webapp.

```
dotnet run
```

Open `https://localhost:5001` in your web browser.


## Publishing a release

Run the publish command.

```
dotnet publish
```

Commit `dist/` folder and merge changes into the develop branch.

Test the changes on the <a href="https://youthful-varahamihira-77e779.netlify.app/">dev version</a> of the website.