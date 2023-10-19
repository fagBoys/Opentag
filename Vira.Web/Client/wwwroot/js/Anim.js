export function ShowAlert(Msg)
{
    alert(Msg);
}

export function AnimCirc(Msg)
{
    gsap.registerPlugin(TextPlugin);

    // 3d tilt effect
    document.body.addEventListener('mousemove', (event) => {
        const posX = (event.clientX / window.innerWidth) - 0.55;
        const posY = (event.clientY / window.innerHeight) - 0.55;

        gsap.to('h1', {
            rotationY: posX * 30,
            rotationX: -posY * 30,
            y: posX * 20,
            x: -posY * 20,
            ease: 'none',
        });

        gsap.to('.emojis', {
            y: posX * 20,
            x: -posY * 20,
            ease: 'none',
        })

        gsap.to('.shape', {
            x: event.clientX,
            y: event.clientY,
        });
    });

    // text animation
    const tl = gsap.timeline({ repeat: -1 });
    tl
        .to('h1', {
            text: {
                value: 'frontend dev,',
                padSpace: true,
                speed: 0.75,
            },
            delay: 3,
        })
        .to('h1', {
            text: {
                value: 'ui/ux designer.',
                padSpace: true,
                speed: 0.75,
            },
            delay: 3,
        })
        .to('h1', {
            text: {
                value: 'hi i\'m gun',
                speed: 0.75,
            },
            delay: 3,
        });

    // text hover effect
    const h1 = document.querySelector('h1');
    h1.addEventListener('mouseover', (event) => {
        gsap.to('.shape', {
            backgroundColor: '#450a0a',
            scale: 20,
        });
    });
    h1.addEventListener('mouseleave', (event) => {
        gsap.to('.shape', {
            backgroundColor: 'transparent',
            scale: 1,
        });
    });
}