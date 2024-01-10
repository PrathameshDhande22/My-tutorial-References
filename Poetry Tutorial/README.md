<div style="display:flex;justify-content:center;align-items:center;width:100%;gap:10px;padding:10px 0px;border:rgb(0, 138, 224) 3px solid;border-radius:50px;color:rgb(0, 185, 235)">
<img src="https://python-poetry.org/images/logo-origami.svg" height=80/>
<div style="font-size:23px;font-weight:700">Python Poetry</div>
</div>

## Python Poetry Tutorial

### About Poetry

Poetry is a tool for dependency management and packaging in Python. It allows you to declare the libraries your project depends on and it will manage (install/update) them for you. Poetry offers a lockfile to ensure repeatable installs, and can build your project for distribution.

In simple terms, Poetry is a simple tool for managing the Dependencies in python. Instead of using the requirements.txt file it's another simple way.

<div style="text-align:center;font-size:20px;font-weight:600;color:orange;">
Forget Pip use Poetry
</div>

### Usage

#### Installation of Poetry Package

Installing the Poetry Package

```
pip install poetry
```

#### Creating the first Poetry Project

```
poetry new project_name
```

These will create a new Poetry Package with these files and directories

```
poetry-demo
├── pyproject.toml
├── README.md
├── poetry_demo
│   └── __init__.py
└── tests
    └── __init__.py
```

In these there is pyproject.toml which contains all the dependencies needed for the project just like the package.json file in node project.

#### Creating in the pre-existing project

```
poetry init
```

These will ask some set of questions like project name, project version, license, etc. although you can redirect without these interactive questions, using the following command.

```
poetry init -n
```

It will create a `pyproject.toml` file in the working directory.

Although if you want to add the virtual environment in the working directory use the following command as the poetry install or create the virtual environment in the cache directory.

```
poetry config virtualenvs.in-project true
```

Then try the following command to create the virtual environment in the current working directory.

```
poetry env use python
```

These will create `.venv` folder containing the virtual environment.

Activate the virtual environment.

```
.venv/Scripts/activate
```

#### Adding the Dependency in the Poetry file

```
poetry add flask
```

Here you can use any package name and it will be automatically added in the pyproject.toml and installed in the venv too.

**If you want to use the old version of package use the following command.**

```
poetry add flask==2.3.0
```

The above command will install the older version of the package name i.e flask.

#### Removing the Dependency from the Project.

```
poetry remove gunicorn
```

These command will remove the dependency from the project.

#### Updating the Dependency Version.

Consider if your dependency has new versions you can update it using the following command.

```
poetry update flask
```

Here we have used the package name as flask you can use any package name.

#### Installing the Package in the another system.

Whenever the python project is shared, we doesn't share the entire venv folder with it. User can install using the following command hence it will create the new venv too.

While Sharing the project do not delete the `poetry.lock` or `pyproject.toml` files.

```
poetry install
```

**Using Poetry you can build the wheel file, publish to pypi also.**

To explore more about Poetry use the official [Documentation](https://python-poetry.org/) or even you can use their interactive commands using `-h` or `help`.

## Author : Prathamesh Dhande
