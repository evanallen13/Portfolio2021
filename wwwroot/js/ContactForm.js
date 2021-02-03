
const formSubmit = () => {
    const fullName = document.getElementById("inputFullname").value;
    const email = document.getElementById("inputEmail").value;
    const message = document.getElementById("inputMessage").value;
    const company = document.getElementById("inputCompany").value;
    const phone = document.getElementById("inputPhone").value;

    const messageJson = {
        Fullname: fullName,
        Email: email,
        Message: message,
        Company: company,
        PhoneNumber: phone
    }
    console.log(messageJson)

    postContactForm(messageJson);
};

const postContactForm = (messageJson) => {

    const uri = `/Home/DoSomething/`;

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(messageJson)
    })
        .then(response => response.json())
        .then((result) => {
            resetContactForm();
        })
        .catch(error => console.error('Unable to add item.', error));
};

const resetContactForm = () => {
    alert("Thank you for reaching out.\nI will be in contact.\n-Evan");
    document.getElementById("inputFullname").value = "";
    document.getElementById("inputEmail").value = "";
    document.getElementById("inputMessage").value = "";
};