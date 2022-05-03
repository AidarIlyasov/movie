<template>
    <div class='custom-modal'>
        <div class="title">
            <slot name='title'/>
        </div>
        <hr>
        <div class="description">
            <slot name='description'/>
        </div>
        <slot />
    </div>
</template>