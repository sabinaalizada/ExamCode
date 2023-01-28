let dlt = document.querySelectorAll(".delete-button")

dlt.forEach(btn => btn.addEventListener("click", function (e) {
    let url = btn.getAttribute("href")

    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            fetch(response)
                .then(response => {
                    if (response.status == 200) {
                        window.location.reload(true)
                    }
                    else {
                        alert("error")
                    }
                })
            
        }
    })
}))

