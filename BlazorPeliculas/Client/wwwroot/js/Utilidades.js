function pruebaPuntoNetStatic() {
	DotNet.invokeMethodAsync("BlazorPeliculas.Client", "ObtenerCurrentCount")
		.then(resultado => {
			console.log('conteo desde javascript ' + resultado);
		//	console.log('jaja');
		})

}

function pruebaPuntoNetInstancia(dotnetHelper) {
	dotnetHelper.invokeMethodAsync("IncrementCount");
}

function timerInactivo(dotnetHelper) {
	var timer;
	document.onmousemove = resetTimer;
	document.onkeypress = resetTimer;

	function resetTimer() {
		clearTimeout(timer);
		//timer = setTimeout(logout, 300*1000) // 5 minutos
	}

	function logout() {
		dotnetHelper.invokeMethodAsync("Logout");
	}
}