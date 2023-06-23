# Initailzing the engine
from typing import Any
from scipy.fft import idst
from sqlalchemy import Column, ForeignKey, String, create_engine, Integer, func, select
from sqlalchemy.orm import DeclarativeBase, Session

# url for connection to sqlite database
url = 'sqlite:///name.db'

# creating the engine connection with sqlite database
engine = create_engine(url, echo=True)

# creating the session
session = Session(engine)

# creating the base class


class Base(DeclarativeBase):
    pass

# creating the tables


class Dept(Base):
    __tablename__ = "department"
    id = Column(Integer, primary_key=True, nullable=False, autoincrement="")
    name = Column(String(20), nullable=False)
    salary = Column(Integer, nullable=False)

    def __init__(self, id, name, salary):
        self.id = id
        self.name = name
        self.salary = salary

    def __repr__(self) -> str:
        return f"Dept{(self.id, self.name, self.salary)}"


class User(Base):
    __tablename__ = "useracc"
    id = Column(Integer, primary_key=True, autoincrement="", nullable=False)
    fname = Column(String(30), nullable=False)
    lname = Column(String(20), nullable=False)
    age = Column(Integer, nullable=False)
    deptid = Column(Integer, ForeignKey(
        Dept.id, ondelete="cascade"), nullable=False)

    def __init__(self, id, fname, lname, age, deptid):
        self.id = id
        self.fname = fname
        self.lname = lname
        self.age = age
        self.deptid = deptid

    def __repr__(self) -> str:
        return f"User{(self.id, self.fname, self.lname, self.age, self.deptid)}"


# if tables are not present then create the new tables
# Base.metadata.create_all(engine, checkfirst=True)

# adding some data in the tables


def addtable1():
    data1 = Dept(id=101, name="Manager", salary=10000)
    data2 = Dept(id=102, name="Salesman", salary=5000)
    data3 = Dept(id=103, name="Worker", salary=1000)
    data4 = Dept(id=104, name="Founder", salary=20000)
    data5 = Dept(id=105, name="Trader", salary=8000)

    # adding these data in the department table
    session.add_all([data1, data2, data3, data4, data5])
    session.flush()
    session.commit()

# addtable1()


def addtabel2():
    from handler import getdatas
    data = getdatas(User=User)
    session.add_all(data)
    session.flush()
    session.commit()

# addtabel2()


# querying the data
stmt = select(User, Dept).join(Dept).order_by(User.id.asc())
print(stmt)
return1 = session.execute(stmt).fetchall()
for ds in return1:
    print(ds)


# aggregation
stmt = select(func.count().label("total"), Dept.name, Dept.salary).select_from(
    User).join(Dept).group_by(User.deptid).order_by(User.deptid.asc())
print(stmt)
return1 = session.execute(stmt).fetchall()
for ds in return1:
    print(ds)
