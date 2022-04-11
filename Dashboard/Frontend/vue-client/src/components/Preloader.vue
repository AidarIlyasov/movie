<template>
	<div class="preloader">
		<div class="spinner-grow" style="width: 3rem; height: 3rem;" role="status">
			<span class="sr-only">Loading...</span>
		</div>
	</div>
</template>

<script>
export default {
	name: "Preloader"
}
</script>
<style scoped>
	.preloader {
		position: absolute;
    width: 100%;
    height: 100vh;
    display: flex;
		background: #fff;
    z-index: 5;
    justify-content: center;
    align-items: center;
	}
</style>
