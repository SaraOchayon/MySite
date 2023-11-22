
const Login = async () => {
    try {
     
        const userName = document.getElementById("userNameRegister").value;
        const password = document.getElementById("passwordRegister").value;
      
        const res = await fetch(`/api/User?userName=${userName}&password=${password}`)
      
        if (!res.ok)
            throw new Error("the user doesnt exist")
     
        const data = await res.json()

        sessionStorage.setItem("User", JSON.stringify(data))
        
        window.location.href = '../../htmls/Update.html'
       
    }
    catch (ex) {
        alert( "sign in because:"+ex)
    }
}
const Register = async() => {
   
    try {
        const user = {
            UserName: document.getElementById("userName").value,
            Password: document.getElementById("password").value,
            FirstName: document.getElementById("firstName").value,
            LastName: document.getElementById("lastName").value,
        }
        if (!user.UserName || !user.Password)
            throw new Error("Error: all field are required");

        const strong = await checkPassword();
        if (strong == 0)
            alert("Your password is weak, Enter password again!");
        else {
            const res = await fetch("/api/user", {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            })



            if (!res.ok)
                throw new Error("the user doesnt add")
            alert("the user added")
        }
    }
    catch (ex) {
        alert(ex)
    }

}
const MoveToRegister = () => {
    document.getElementById("register").style.visibility = "visible";
}
const Update = () => {
    document.getElementById("register").style.visibility = "visible";
    const userString = JSON.parse(sessionStorage.getItem("User"))
    document.getElementById("userName").value = userString.userName;
    document.getElementById("password").value = userString.password;
    document.getElementById("firstName").value = userString.firstName;
    document.getElementById("lastName").value = userString.lastName;
}
const Save = async () => {
    const userString = sessionStorage.getItem("User")
    const id = JSON.parse(userString).userId
    const userName = document.getElementById("userName").value
    const password = document.getElementById("password").value
    const firstName = document.getElementById("firstName").value
    const lastName = document.getElementById("lastName").value

    const user = { userName, password, firstName, lastName }
    if (!user.userName || !user.password )
        throw new Error("Error: all fields are required");

    const strong =  checkPassword();
    if (strong == 0)
        alert("Your password is weak, Enter password again!");
    try {
        const res = await fetch(`api/User/${id}`,
            {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body:JSON.stringify(user)

﻿
            })
    
        if (!res.ok)
            throw new Error("Error update user to server")
        sessionStorage.setItem("User", JSON.stringify(user))
       alert(`user ${JSON.parse(sessionStorage.getItem("User")).userName} was updated`)
    }
    catch (ex)
    {
        alert(ex.message)
        
    }


}
const checkPassword = async () => {
    const pass = document.getElementById("password").value
    try {
        const check = await fetch("/api/user/checkPassword", {
            method: 'POST',
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify(pass)
        })
        if (!check.ok)
            throw new Error("Error: Check password strength failed")

        const score = await check.json()
        document.getElementById("progress").value = score;

        if (score > 2)
            return 1;
        else
            return 0;
    }
    catch (err) {
        alert(err)
    }

}
