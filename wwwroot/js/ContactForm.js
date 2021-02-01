

const formSubmit = () => {
    const uri = "/Home/DoSomething"
    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        //body: JSON.stringify("HEllo")
    })
        .then(response => response.json())
        .then((result) => {
            console.log(result)
        })
        .catch(error => console.error('Unable to add item.', error));
}