function register() {
    const registrationEndpoint = document.getElementById('registrationEndpoint').value;
    const id = document.getElementById('id').value;
    const teamName = document.getElementById('teamName').value;
    const createJobEndpoint = document.getElementById('createJobEndpoint').value;
    const errorCheckEndpoint = document.getElementById('errorCheckEndpoint').value;
    console.log('registrationEndpoint: ' + registrationEndpoint);
    console.log('id: ' + id);
    console.log('teamName: ' + teamName);
    console.log('createJobEndpoint: ' + createJobEndpoint);
    console.log('errorCheckEndpoint: ' + errorCheckEndpoint);

    const body = {
        registerEndpoint: registrationEndpoint,
        workerId: id,
        teamName,
        createJobEndpoint,
        errorCheckEndpoint
    };
    fetch('/register', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(body)
    });
}