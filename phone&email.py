import re

def validemail(email):
    re_email=re.compile(r"([A-Za-z0-9._%+-]+@[A-Za-z]+\.[A-Z|a-z]{3})")
    if re_email.match(email):
        print("Valid Email")
    else:
        print("Invalid Email")

def validPhone(phone):
    re_phn=re.compile(r"^[+0-9]+\s[0-9]{10}|^[+0-9]{12}")
    if re_phn.match(phone):
        print("Valid Phone Number")
    else:
        print("Invalid Phone Number")
    
print("---------Phone Number & Email Validator---------")
email=input("Enter the Email : ")
validemail(email=email)
phoneno=input("Enter the Phone Number Including the +91 : ")
validPhone(phoneno)