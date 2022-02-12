function modalGuardar(titulo = "¿Deseas guardar los cambios?", texto = "¿Deseas guardar los cambios?") {
    return Swal.fire({
        title: titulo,
        text: texto,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Acceptar'
    })
}